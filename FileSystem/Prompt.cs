using System.Windows.Forms;

namespace FileSystem
{
    public static class Prompt
    {
        public static string ShowDialog(string caption, string label, string defaultValue)
        {
            var prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            var textLabel = new Label() {Left = 50, Top = 20, Text = label};
            var textBox = new TextBox() {Left = 50, Top = 40, Width = 400, Text = defaultValue};
            var confirmation = new Button()
            {
                Text = caption,
                Left = 350,
                Width = 100,
                Top = 70,
                DialogResult = DialogResult.OK
            };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}