﻿namespace lab_3
{
    partial class serializeForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelAdd = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.comboBoxItems = new System.Windows.Forms.ComboBox();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.listBoxOfProducts = new System.Windows.Forms.ListBox();
            this.labelEdit = new System.Windows.Forms.Label();
            this.menuStripFile = new System.Windows.Forms.MenuStrip();
            this.работаСФайломToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сериализоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.десToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonClearList = new System.Windows.Forms.Button();
            this.buttonLoadPlugin = new System.Windows.Forms.Button();
            this.buttonSignPlugin = new System.Windows.Forms.Button();
            this.buttonFuncPlugin = new System.Windows.Forms.Button();
            this.panelCrypto = new System.Windows.Forms.Panel();
            this.dllComboBox = new System.Windows.Forms.ComboBox();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.menuStripFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(828, 716);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 28);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // panelAdd
            // 
            this.panelAdd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelAdd.Location = new System.Drawing.Point(39, 98);
            this.panelAdd.Margin = new System.Windows.Forms.Padding(4);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(349, 612);
            this.panelAdd.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(164, 718);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 28);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(547, 718);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(123, 28);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // comboBoxItems
            // 
            this.comboBoxItems.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxItems.FormattingEnabled = true;
            this.comboBoxItems.Location = new System.Drawing.Point(39, 42);
            this.comboBoxItems.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxItems.Name = "comboBoxItems";
            this.comboBoxItems.Size = new System.Drawing.Size(348, 24);
            this.comboBoxItems.TabIndex = 6;
            this.comboBoxItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxItems_SelectedIndexChanged);
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelEdit.Location = new System.Drawing.Point(437, 98);
            this.panelEdit.Margin = new System.Windows.Forms.Padding(4);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(341, 612);
            this.panelEdit.TabIndex = 7;
            // 
            // listBoxOfProducts
            // 
            this.listBoxOfProducts.FormattingEnabled = true;
            this.listBoxOfProducts.ItemHeight = 16;
            this.listBoxOfProducts.Location = new System.Drawing.Point(828, 97);
            this.listBoxOfProducts.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxOfProducts.Name = "listBoxOfProducts";
            this.listBoxOfProducts.Size = new System.Drawing.Size(223, 612);
            this.listBoxOfProducts.TabIndex = 8;
            this.listBoxOfProducts.SelectedIndexChanged += new System.EventHandler(this.listBoxOfProducts_SelectedIndexChanged);
            // 
            // labelEdit
            // 
            this.labelEdit.AutoSize = true;
            this.labelEdit.Location = new System.Drawing.Point(543, 42);
            this.labelEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEdit.Name = "labelEdit";
            this.labelEdit.Size = new System.Drawing.Size(0, 17);
            this.labelEdit.TabIndex = 9;
            // 
            // menuStripFile
            // 
            this.menuStripFile.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.работаСФайломToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStripFile.Location = new System.Drawing.Point(0, 0);
            this.menuStripFile.Name = "menuStripFile";
            this.menuStripFile.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripFile.Size = new System.Drawing.Size(1463, 28);
            this.menuStripFile.TabIndex = 10;
            // 
            // работаСФайломToolStripMenuItem
            // 
            this.работаСФайломToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сериализоватьToolStripMenuItem,
            this.десToolStripMenuItem});
            this.работаСФайломToolStripMenuItem.Name = "работаСФайломToolStripMenuItem";
            this.работаСФайломToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.работаСФайломToolStripMenuItem.Text = "Работа с файлом";
            // 
            // сериализоватьToolStripMenuItem
            // 
            this.сериализоватьToolStripMenuItem.Name = "сериализоватьToolStripMenuItem";
            this.сериализоватьToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.сериализоватьToolStripMenuItem.Text = "Сериализовать";
            this.сериализоватьToolStripMenuItem.Click += new System.EventHandler(this.serializeToolStripMenuItem_Click);
            // 
            // десToolStripMenuItem
            // 
            this.десToolStripMenuItem.Name = "десToolStripMenuItem";
            this.десToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.десToolStripMenuItem.Text = "Десериализовать";
            this.десToolStripMenuItem.Click += new System.EventHandler(this.deserializeToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Text files(*.txt)|*.txt";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text files(*.txt)|*.txt";
            // 
            // buttonClearList
            // 
            this.buttonClearList.Location = new System.Drawing.Point(952, 716);
            this.buttonClearList.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonClearList.Size = new System.Drawing.Size(100, 28);
            this.buttonClearList.TabIndex = 11;
            this.buttonClearList.Text = "Очистить";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.buttonClearList_Click);
            // 
            // buttonLoadPlugin
            // 
            this.buttonLoadPlugin.Location = new System.Drawing.Point(1145, 98);
            this.buttonLoadPlugin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadPlugin.Name = "buttonLoadPlugin";
            this.buttonLoadPlugin.Size = new System.Drawing.Size(224, 28);
            this.buttonLoadPlugin.TabIndex = 12;
            this.buttonLoadPlugin.Text = "Расширить иерархию";
            this.buttonLoadPlugin.UseVisualStyleBackColor = true;
            this.buttonLoadPlugin.Click += new System.EventHandler(this.buttonLoadPlugin_Click);
            // 
            // buttonSignPlugin
            // 
            this.buttonSignPlugin.Location = new System.Drawing.Point(1145, 190);
            this.buttonSignPlugin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSignPlugin.Name = "buttonSignPlugin";
            this.buttonSignPlugin.Size = new System.Drawing.Size(224, 28);
            this.buttonSignPlugin.TabIndex = 14;
            this.buttonSignPlugin.Text = "Подписать плагин";
            this.buttonSignPlugin.UseVisualStyleBackColor = true;
            this.buttonSignPlugin.Click += new System.EventHandler(this.buttonSignPlugin_Click);
            // 
            // buttonFuncPlugin
            // 
            this.buttonFuncPlugin.Location = new System.Drawing.Point(1145, 134);
            this.buttonFuncPlugin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFuncPlugin.Name = "buttonFuncPlugin";
            this.buttonFuncPlugin.Size = new System.Drawing.Size(224, 48);
            this.buttonFuncPlugin.TabIndex = 15;
            this.buttonFuncPlugin.Text = "Загрузить функциональный плагин";
            this.buttonFuncPlugin.UseVisualStyleBackColor = true;
            this.buttonFuncPlugin.Click += new System.EventHandler(this.buttonFuncPlugin_Click);
            // 
            // panelCrypto
            // 
            this.panelCrypto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCrypto.Location = new System.Drawing.Point(1103, 280);
            this.panelCrypto.Margin = new System.Windows.Forms.Padding(4);
            this.panelCrypto.Name = "panelCrypto";
            this.panelCrypto.Size = new System.Drawing.Size(319, 430);
            this.panelCrypto.TabIndex = 16;
            // 
            // dllComboBox
            // 
            this.dllComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dllComboBox.FormattingEnabled = true;
            this.dllComboBox.Location = new System.Drawing.Point(1124, 236);
            this.dllComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.dllComboBox.Name = "dllComboBox";
            this.dllComboBox.Size = new System.Drawing.Size(279, 24);
            this.dllComboBox.TabIndex = 17;
            this.dllComboBox.SelectedIndexChanged += new System.EventHandler(this.dllComboBox_SelectedIndexChanged_1);
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(1103, 716);
            this.buttonEncrypt.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(152, 54);
            this.buttonEncrypt.TabIndex = 18;
            this.buttonEncrypt.Text = "Зашифровать и сохранить";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click_1);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(1263, 718);
            this.buttonDecrypt.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(159, 54);
            this.buttonDecrypt.TabIndex = 19;
            this.buttonDecrypt.Text = "Расшифровать и загрузить";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click_1);
            // 
            // serializeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 785);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.dllComboBox);
            this.Controls.Add(this.panelCrypto);
            this.Controls.Add(this.buttonFuncPlugin);
            this.Controls.Add(this.buttonSignPlugin);
            this.Controls.Add(this.buttonLoadPlugin);
            this.Controls.Add(this.buttonClearList);
            this.Controls.Add(this.labelEdit);
            this.Controls.Add(this.listBoxOfProducts);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.comboBoxItems);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.panelAdd);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.menuStripFile);
            this.MainMenuStrip = this.menuStripFile;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "serializeForm";
            this.Text = "Лаб. работа №3";
            this.menuStripFile.ResumeLayout(false);
            this.menuStripFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelAdd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ComboBox comboBoxItems;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.ListBox listBoxOfProducts;
        private System.Windows.Forms.Label labelEdit;
        private System.Windows.Forms.MenuStrip menuStripFile;
        private System.Windows.Forms.ToolStripMenuItem работаСФайломToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сериализоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem десToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonClearList;
        private System.Windows.Forms.Button buttonLoadPlugin;
        private System.Windows.Forms.Button buttonSignPlugin;
        private System.Windows.Forms.Button buttonFuncPlugin;
        private System.Windows.Forms.Panel panelCrypto;
        private System.Windows.Forms.ComboBox dllComboBox;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Button buttonDecrypt;
    }
}

