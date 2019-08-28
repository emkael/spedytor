using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace spedytor
{
    class Logger
    {
        private static Logger instance;
        private StreamWriter file;
        private TextBox field;
        private List<string> messages;
        private object queueLog;

        private Logger()
        {
            Logger.instance = this;
            this.messages = new List<string>();
            this.queueLog = new object();
        }

        private void setFile(string filename) {
            if (this.file == null)
            {
                this.file = new StreamWriter(filename);
            }
        }

        private void setField(TextBox field)
        {
            this.field = field;
        }

        public static Logger getLogger(TextBox textField = null, string file = null)
        {
            if (Logger.instance == null)
            {
                Logger.instance = new Logger();
            }
            if (file != null)
            {
                Logger.instance.setFile(file);
            }
            if (textField != null)
            {
                Logger.instance.setField(textField);
            }
            return Logger.instance;
        }

        public void log(string message)
        {
            lock (this.queueLog)
            {
                this.messages.Add(message);
            }
        }

        public void tick()
        {
            List<string> messages = new List<string>();
            lock (this.queueLog)
            {
                messages = this.messages.GetRange(0, this.messages.Count);
                this.messages.Clear();
            }
            foreach (string message in messages)
            {
                string line = String.Format("[{0}] {1}{2}", DateTime.Now.ToString(), message, Environment.NewLine);
                if (this.field != null)
                {
                    this.field.Text += line;
                }
                if (this.file != null)
                {
                    this.file.Write(line);
                }
            }
        }
    }
}
