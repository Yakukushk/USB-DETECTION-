using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

namespace UsbDetect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Function_For_Button
        private void button1_Click(object sender, EventArgs e)
        {
            ManagementObjectCollection collection;
            using (var FinderDevices = new ManagementObjectSearcher(@"Select * From Win32_USBHub")) {
            collection = FinderDevices.Get();
                foreach (var item in collection) {
                checkedListBox1.Items.Add(item.GetPropertyValue("DeviceID"));
                checkedListBox1.Items.Add(item.GetPropertyValue("Description"));
                }
            }
            
        }
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < checkedListBox1.Items.Count; i++) {
                checkedListBox1.SetItemCheckState(i, (checkBox1.Checked ? CheckState.Checked : CheckState.Unchecked));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();  
        }
    }
}