using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class MainForm : Form
    {
        private readonly ConcurrentBag<string> _logEntries = new ConcurrentBag<string>();
        private bool _isProcessing = false;
        private CancellationTokenSource _cancellationTokenSource;

        public MainForm()
        {
            InitializeComponent();
            cmbTimePeriod.SelectedIndex = 0;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void LogAction(string message)
        {
            var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            _logEntries.Add(logMessage);
            Console.WriteLine(logMessage); // ��� �������
        }

        private async void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFolderPath.Text = folderDialog.SelectedPath;
                    await LoadFolderStatsAsync(folderDialog.SelectedPath);
                }
            }
        }

        private async Task LoadFolderStatsAsync(string folderPath)
        {
            try
            {
                lblStatus.Text = "������ �����...";
                progressBar.Value = 0;
                _isProcessing = true;
                EnableControls(false);

                var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp" };
                var allFiles = await Task.Run(() =>
                    Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories)
                        .Where(f => imageExtensions.Contains(Path.GetExtension(f).ToLowerInvariant()))
                        .ToArray());

                Invoke((Action)(() => lblFileCount.Text = $"������: {allFiles.Length:N0}"));
                LogAction($"���������������� �����: {folderPath}. ������� {allFiles.Length:N0} �����������.");
            }
            catch (Exception ex)
            {
                LogAction($"������ ��� ������� �����: {ex.Message}");
                MessageBox.Show($"������ ��� ������� �����: {ex.Message}", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
                EnableControls(true);
                UpdateStatus("�����");
            }
        }

        private async void btnSearchDuplicates_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            if (string.IsNullOrWhiteSpace(txtFolderPath.Text) || !Directory.Exists(txtFolderPath.Text))
            {
                MessageBox.Show("����������, �������� ���������� ����� ��� ������.",
                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lvDuplicates.BeginUpdate();
            lvDuplicates.Items.Clear();
            lvDuplicates.EndUpdate();

            progressBar.Value = 0;
            _isProcessing = true;
            EnableControls(false);
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await FindDuplicatesAsync(txtFolderPath.Text, _cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                UpdateStatus("�������� ��������");
                LogAction("����� ���������� ������� �������������");
            }
            catch (Exception ex)
            {
                LogAction($"������ ��� ������ ����������: {ex.Message}");
                MessageBox.Show($"������ ��� ������ ����������: {ex.Message}",
                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
                EnableControls(true);
            }
        }

        private async Task FindDuplicatesAsync(string folderPath, CancellationToken cancellationToken)
        {
            UpdateStatus("����� ����������...");
            LogAction($"������ ������ ���������� � �����: {folderPath}");

            var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp" };
            var allFiles = await Task.Run(() =>
                Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories)
                    .Where(f => imageExtensions.Contains(Path.GetExtension(f).ToLowerInvariant()))
                    .ToArray(), cancellationToken);

            progressBar.Maximum = allFiles.Length;

            var duplicates = await Task.Run(() =>
            {
                var filesWithInfo = new List<FileInfo>();
                foreach (var file in allFiles)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    try
                    {
                        filesWithInfo.Add(new FileInfo(file));
                        UpdateProgress(1);
                    }
                    catch (Exception ex)
                    {
                        LogAction($"������ ��� ��������� ����� {file}: {ex.Message}");
                    }
                }

                return filesWithInfo
                    .GroupBy(f => new { Name = f.Name.ToLowerInvariant(), f.Length })
                    .Where(g => g.Count() > 1)
                    .ToList();
            }, cancellationToken);

            lvDuplicates.BeginUpdate();
            try
            {
                foreach (var group in duplicates)
                {
                    var groupFiles = group.ToList();
                    var firstFile = groupFiles.First();

                    foreach (var file in groupFiles)
                    {
                        var item = new ListViewItem(file.Name);
                        item.SubItems.Add((file.Length / 1024).ToString("N0") + " KB");
                        item.SubItems.Add(file.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        item.SubItems.Add(file.DirectoryName);
                        item.Tag = file.FullName;

                        if (file.FullName == firstFile.FullName)
                        {
                            item.BackColor = System.Drawing.Color.LightGreen;
                            item.ToolTipText = "�������� (�� ����� ������)";
                        }

                        lvDuplicates.Items.Add(item);
                    }

                    lvDuplicates.Items.Add(new ListViewItem(""));
                }
            }
            finally
            {
                lvDuplicates.EndUpdate();
            }

            UpdateStatus($"������� {duplicates.Count:N0} ����� ����������.");
            LogAction($"������� {duplicates.Count:N0} ����� ���������� � �����: {folderPath}");
        }

        private async void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            if (lvDuplicates.SelectedItems.Count == 0)
            {
                MessageBox.Show("����������, �������� ��������� ��� ��������.",
                    "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var itemsToDelete = lvDuplicates.SelectedItems.Cast<ListViewItem>()
                .Where(item => item.BackColor != System.Drawing.Color.LightGreen && !string.IsNullOrEmpty(item.Text))
                .ToList();

            if (!itemsToDelete.Any())
            {
                MessageBox.Show("�� ������� ������ ������������ ����� (�������), ������� �� ����� �������.",
                    "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"�� �������, ��� ������ ������� {itemsToDelete.Count:N0} ��������� ����������?",
                "������������� ��������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            await DeleteFilesAsync(itemsToDelete);
        }

        private async void btnDeleteAllDuplicates_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            var itemsToDelete = lvDuplicates.Items.Cast<ListViewItem>()
                .Where(item => item.BackColor != System.Drawing.Color.LightGreen && !string.IsNullOrEmpty(item.Text))
                .ToList();

            if (!itemsToDelete.Any())
            {
                MessageBox.Show("��� ���������� ��� ��������.",
                    "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"�� �������, ��� ������ ������� ��� {itemsToDelete.Count:N0} ���������� (����� ����������)?",
                "������������� ��������", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            await DeleteFilesAsync(itemsToDelete);
        }

        private async Task DeleteFilesAsync(List<ListViewItem> itemsToDelete)
        {
            _isProcessing = true;
            EnableControls(false);
            progressBar.Maximum = itemsToDelete.Count;
            progressBar.Value = 0;
            UpdateStatus("�������� ������...");

            int successCount = 0;
            int failCount = 0;

            await Task.Run(() =>
            {
                foreach (var item in itemsToDelete)
                {
                    try
                    {
                        _cancellationTokenSource.Token.ThrowIfCancellationRequested();

                        File.Delete(item.Tag.ToString());
                        LogAction($"������ ����: {item.Tag}");

                        Invoke((Action)(() => {
                            lvDuplicates.Items.Remove(item);
                            progressBar.Value++;
                        }));

                        successCount++;
                    }
                    catch (OperationCanceledException)
                    {
                        LogAction("�������� ������ �������� �������������");
                        break;
                    }
                    catch (Exception ex)
                    {
                        failCount++;
                        LogAction($"������ ��� �������� ����� {item.Tag}: {ex.Message}");

                        Invoke((Action)(() => {
                            item.ToolTipText = $"������ ��������: {ex.Message}";
                            item.BackColor = System.Drawing.Color.LightPink;
                        }));
                    }
                }
            }, _cancellationTokenSource.Token);

            UpdateStatus($"������� {successCount:N0} ������. �� ������� ������� {failCount:N0} ������.");
            LogAction($"���� ��������: ������� {successCount:N0}, ������ {failCount:N0}");

            if (_cancellationTokenSource.Token.IsCancellationRequested)
            {
                MessageBox.Show($"�������� ��������. ������� {successCount:N0} ������.",
                    "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"������� {successCount:N0} ������. �� ������� ������� {failCount:N0} ������.",
                    "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _isProcessing = false;
            EnableControls(true);
        }

        private async void btnSortByDate_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            if (string.IsNullOrWhiteSpace(txtFolderPath.Text) || !Directory.Exists(txtFolderPath.Text))
            {
                MessageBox.Show("����������, �������� ���������� ����� ��� ����������.",
                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isProcessing = true;
            EnableControls(false);
            progressBar.Value = 0;
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await SortFilesByDateAsync(txtFolderPath.Text, cmbTimePeriod.SelectedItem.ToString(),
                    _cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                UpdateStatus("�������� ��������");
                LogAction("���������� �� ���� �������� �������������");
            }
            catch (Exception ex)
            {
                LogAction($"������ ��� ���������� ������: {ex.Message}");
                MessageBox.Show($"������ ��� ���������� ������: {ex.Message}",
                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
                EnableControls(true);
            }
        }

        private async Task SortFilesByDateAsync(string sourcePath, string timePeriod, CancellationToken cancellationToken)
        {
            UpdateStatus("���������� ������...");
            LogAction($"������ ���������� ������ � �����: {sourcePath} �� �������: {timePeriod}");

            var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp" };
            var allFiles = await Task.Run(() =>
                Directory.EnumerateFiles(sourcePath, "*.*", SearchOption.AllDirectories)
                    .Where(f => imageExtensions.Contains(Path.GetExtension(f).ToLowerInvariant()))
                    .ToArray(), cancellationToken);

            progressBar.Maximum = allFiles.Length;

            var destinationRoot = Path.Combine(sourcePath, "SortedPhotos_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            Directory.CreateDirectory(destinationRoot);

            int movedCount = 0;
            int skipCount = 0;
            int errorCount = 0;

            await Task.Run(() =>
            {
                foreach (var file in allFiles)
                {
                    try
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        var creationTime = File.GetCreationTime(file);
                        string folderName = GetFolderNameByTimePeriod(creationTime, timePeriod);

                        var destinationFolder = Path.Combine(destinationRoot, folderName);
                        Directory.CreateDirectory(destinationFolder);

                        var destinationFile = Path.Combine(destinationFolder, Path.GetFileName(file));

                        if (!File.Exists(destinationFile))
                        {
                            File.Move(file, destinationFile);
                            LogAction($"��������� ����: {file} -> {destinationFile}");
                            movedCount++;
                        }
                        else
                        {
                            LogAction($"���� ��� ����������, �������: {destinationFile}");
                            skipCount++;
                        }

                        UpdateProgress(1);
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        LogAction($"������ ��� ����������� ����� {file}: {ex.Message}");
                    }
                }

                // ������� ������ ����� ����� ����������
                foreach (var dir in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories)
                    .Where(d => !d.StartsWith(destinationRoot) && !Directory.EnumerateFileSystemEntries(d).Any()))
                {
                    try
                    {
                        Directory.Delete(dir);
                        LogAction($"������� ������ �����: {dir}");
                    }
                    catch (Exception ex)
                    {
                        LogAction($"������ ��� �������� ������ ����� {dir}: {ex.Message}");
                    }
                }
            }, cancellationToken);

            UpdateStatus($"���������� ���������. ����������: {movedCount:N0}, ���������: {skipCount:N0}, ������: {errorCount:N0}");
            LogAction($"���� ����������: ���������� {movedCount:N0}, ��������� {skipCount:N0}, ������ {errorCount:N0}");

            if (!cancellationToken.IsCancellationRequested)
            {
                MessageBox.Show($"���������� ���������.\n����������: {movedCount:N0}\n���������: {skipCount:N0}\n������: {errorCount:N0}",
                    "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetFolderNameByTimePeriod(DateTime date, string timePeriod)
        {
            switch (timePeriod)
            {
                case "����":
                    return date.ToString("yyyy-MM-dd");
                case "������":
                    var startOfWeek = date.AddDays(-(int)date.DayOfWeek);
                    return $"Week_{startOfWeek:yyyy-MM-dd}";
                case "�����":
                    return date.ToString("yyyy-MM");
                default:
                    return "Other";
            }
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            var logForm = new LogForm(_logEntries.ToList());
            logForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isProcessing)
            {
                _cancellationTokenSource.Cancel();
                UpdateStatus("������ ��������...");
            }
        }

        private void EnableControls(bool enable)
        {
            btnSelectFolder.Enabled = enable;
            btnSearchDuplicates.Enabled = enable;
            btnDeleteSelected.Enabled = enable && lvDuplicates.Items.Count > 0;
            btnDeleteAllDuplicates.Enabled = enable && lvDuplicates.Items.Count > 0;
            btnSortByDate.Enabled = enable;
            btnShowLog.Enabled = enable;
            //btnCancel.Enabled = !enable;
        }

        private void UpdateStatus(string message)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => lblStatus.Text = message));
            }
            else
            {
                lblStatus.Text = message;
            }
        }

        private void UpdateProgress(int increment = 1)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => progressBar.Value += increment));
            }
            else
            {
                progressBar.Value += increment;
            }
        }

        private void lvDuplicates_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteSelected.Enabled = lvDuplicates.SelectedItems.Count > 0 && !_isProcessing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
