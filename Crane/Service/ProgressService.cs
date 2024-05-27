using CTG_Control.Crane.Model.Bean;

namespace CTG_Control.Crane.Service
{
    /// <summary>
    /// 进度条服务
    /// 该服务已废弃
    /// </summary>
    [Obsolete("因为该程序使用winrar指令执行压缩，无法跟踪进度，故进度条无实际意义", false)]
    internal class ProgressService
    {

        private ProgressBar progressBar;
        private int fileCount;
        private Label progressLabel;

        public ProgressService() { }

        /// <summary>
        /// 一般情况下启动进度条都是另外开线程的，所以在这里开线程
        /// progressBar组件
        /// </summary>
        /// <param name="progressBar"></param>
        /// <param name="fileCount"></param>
        public void StartProgress(long fileCount, string title)
        {
            ExecutingForm executingForm = new ExecutingForm();
            executingForm.Text = title;
            executingForm.Show();
            this.progressBar = executingForm.progressBar;
            this.fileCount = (int)(fileCount / (ConfigService.GetValueByBool("sfx") ? 5000 : 10000));
            this.progressLabel = executingForm.progressBarLabel;
            Thread progressBarThread = new(new ThreadStart(InnerExecute))
            {
                Priority = ThreadPriority.Highest,
                IsBackground = true
            };
            progressBarThread.Start();
        }

        public void StartProgress(long fileCount, CompressItem compressItem)
        {
            new ProgressService().StartProgress(fileCount, compressItem.SourcePath + " -> " + compressItem.TargetPath);
        }

        private void InnerExecute()
        {
            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Maximum = fileCount;
            progressBar.Minimum = 0;
            progressBar.MarqueeAnimationSpeed = 100;
            progressBar.Step = 1;

            for (int i = 0; i < fileCount; i++)
            {
                //progressBar.Value这玩意是int，得先转为double，不然永远是0
                double progressBarValue = progressBar.Value;
                double percent = progressBarValue / fileCount * 100;
                //  if (percent > 99.99) { break; }
                progressBar.PerformStep();
                progressLabel.Text = Math.Round(percent, 2) + "%";
                progressBar.Refresh();
            }

        }

    }
}
