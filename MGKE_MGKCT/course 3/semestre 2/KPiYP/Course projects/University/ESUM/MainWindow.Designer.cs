
namespace ESUM
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Аспирантура");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Докторские");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Кандидатские");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Научные темы");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Научные направления");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Нагрузки");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Преподаватели", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Учебные поручения");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Кафедры", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Дипломные работы");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Контроль");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Студенты", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Группы", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Факультеты", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Учебные планы");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Дисциплины", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createReport = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToWord = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToTXT = new System.Windows.Forms.ToolStripMenuItem();
            this.reportOnMail = new System.Windows.Forms.ToolStripMenuItem();
            this.reportOnPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tableMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllTabsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.myProfileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.usersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.abouMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.userHelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.myProfileToolStrip = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.AddToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.EditToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.DeleteToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripOnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripOnWord = new System.Windows.Forms.ToolStripButton();
            this.toolStripOnTxt = new System.Windows.Forms.ToolStripButton();
            this.toolStripOnEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripGraphic = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.PropertyPanel = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statNodePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.empt = new System.Windows.Forms.ToolStripStatusLabel();
            this.statSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.HotKeysMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.PropertyPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(160, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.tableMenu,
            this.settingsMenu,
            this.toolStripMenuItem6,
            this.usersMenu,
            this.helpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(817, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createReport,
            this.reportOnPrint,
            this.toolStripSeparator2,
            this.exitMenu});
            this.fileMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "&Файл";
            this.fileMenu.MouseEnter += new System.EventHandler(this.fileMenu_MouseEnter);
            this.fileMenu.MouseLeave += new System.EventHandler(this.fileMenu_MouseLeave);
            // 
            // createReport
            // 
            this.createReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToExcel,
            this.reportToWord,
            this.reportToTXT,
            this.reportOnMail});
            this.createReport.Image = ((System.Drawing.Image)(resources.GetObject("createReport.Image")));
            this.createReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createReport.Name = "createReport";
            this.createReport.Size = new System.Drawing.Size(154, 22);
            this.createReport.Text = "Создать отчет";
            // 
            // reportToExcel
            // 
            this.reportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("reportToExcel.Image")));
            this.reportToExcel.Name = "reportToExcel";
            this.reportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.reportToExcel.Size = new System.Drawing.Size(211, 22);
            this.reportToExcel.Text = "В Excel";
            this.reportToExcel.Click += new System.EventHandler(this.exportToExcel);
            // 
            // reportToWord
            // 
            this.reportToWord.Image = ((System.Drawing.Image)(resources.GetObject("reportToWord.Image")));
            this.reportToWord.Name = "reportToWord";
            this.reportToWord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.reportToWord.Size = new System.Drawing.Size(211, 22);
            this.reportToWord.Text = "В Word";
            this.reportToWord.Click += new System.EventHandler(this.exportToWord);
            // 
            // reportToTXT
            // 
            this.reportToTXT.Image = ((System.Drawing.Image)(resources.GetObject("reportToTXT.Image")));
            this.reportToTXT.Name = "reportToTXT";
            this.reportToTXT.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.reportToTXT.Size = new System.Drawing.Size(211, 22);
            this.reportToTXT.Text = "В Текстовый файл";
            this.reportToTXT.Click += new System.EventHandler(this.exportToTXT);
            // 
            // reportOnMail
            // 
            this.reportOnMail.Image = ((System.Drawing.Image)(resources.GetObject("reportOnMail.Image")));
            this.reportOnMail.Name = "reportOnMail";
            this.reportOnMail.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.reportOnMail.Size = new System.Drawing.Size(211, 22);
            this.reportOnMail.Text = "На эл. почту";
            this.reportOnMail.Click += new System.EventHandler(this.sendOnEmail);
            // 
            // reportOnPrint
            // 
            this.reportOnPrint.Image = ((System.Drawing.Image)(resources.GetObject("reportOnPrint.Image")));
            this.reportOnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reportOnPrint.Name = "reportOnPrint";
            this.reportOnPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.reportOnPrint.Size = new System.Drawing.Size(154, 22);
            this.reportOnPrint.Text = "Печать";
            this.reportOnPrint.Click += new System.EventHandler(this.printTable);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Image = ((System.Drawing.Image)(resources.GetObject("exitMenu.Image")));
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenu.Size = new System.Drawing.Size(154, 22);
            this.exitMenu.Text = "Выход";
            this.exitMenu.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tableMenu
            // 
            this.tableMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAllTabsMenu,
            this.toolStripSeparator4,
            this.addMenu,
            this.editMenu,
            this.deleteMenu});
            this.tableMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableMenu.Name = "tableMenu";
            this.tableMenu.Size = new System.Drawing.Size(68, 20);
            this.tableMenu.Text = "&Таблицы";
            this.tableMenu.MouseEnter += new System.EventHandler(this.fileMenu_MouseEnter);
            this.tableMenu.MouseLeave += new System.EventHandler(this.fileMenu_MouseLeave);
            // 
            // closeAllTabsMenu
            // 
            this.closeAllTabsMenu.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.closeAllTabsMenu.Name = "closeAllTabsMenu";
            this.closeAllTabsMenu.Size = new System.Drawing.Size(203, 22);
            this.closeAllTabsMenu.Text = "Закрыть все вкладки";
            this.closeAllTabsMenu.Click += new System.EventHandler(this.closeAllTabs);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(200, 6);
            // 
            // addMenu
            // 
            this.addMenu.BackColor = System.Drawing.Color.LimeGreen;
            this.addMenu.Name = "addMenu";
            this.addMenu.Size = new System.Drawing.Size(203, 22);
            this.addMenu.Text = "Добавить в выбранную";
            this.addMenu.Click += new System.EventHandler(this.AddToolStripBtn_Click);
            // 
            // editMenu
            // 
            this.editMenu.BackColor = System.Drawing.Color.GreenYellow;
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(203, 22);
            this.editMenu.Text = "Изменить выбранную";
            this.editMenu.Click += new System.EventHandler(this.EditToolStripBtn_Click);
            // 
            // deleteMenu
            // 
            this.deleteMenu.BackColor = System.Drawing.Color.Firebrick;
            this.deleteMenu.Name = "deleteMenu";
            this.deleteMenu.Size = new System.Drawing.Size(203, 22);
            this.deleteMenu.Text = "Удалить выбранную";
            this.deleteMenu.Click += new System.EventHandler(this.DeleteToolStripBtn_Click);
            // 
            // settingsMenu
            // 
            this.settingsMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(79, 20);
            this.settingsMenu.Text = "&Настройки";
            this.settingsMenu.Click += new System.EventHandler(this.settingsMenu_Click);
            this.settingsMenu.MouseEnter += new System.EventHandler(this.fileMenu_MouseEnter);
            this.settingsMenu.MouseLeave += new System.EventHandler(this.fileMenu_MouseLeave);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myProfileMenu,
            this.changeUser});
            this.toolStripMenuItem6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(71, 20);
            this.toolStripMenuItem6.Text = "П&рофиль";
            this.toolStripMenuItem6.MouseEnter += new System.EventHandler(this.fileMenu_MouseEnter);
            this.toolStripMenuItem6.MouseLeave += new System.EventHandler(this.fileMenu_MouseLeave);
            // 
            // myProfileMenu
            // 
            this.myProfileMenu.Image = ((System.Drawing.Image)(resources.GetObject("myProfileMenu.Image")));
            this.myProfileMenu.Name = "myProfileMenu";
            this.myProfileMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.myProfileMenu.Size = new System.Drawing.Size(243, 22);
            this.myProfileMenu.Text = "Мой профиль";
            this.myProfileMenu.Click += new System.EventHandler(this.myProfileMenu_Click);
            // 
            // changeUser
            // 
            this.changeUser.Image = ((System.Drawing.Image)(resources.GetObject("changeUser.Image")));
            this.changeUser.Name = "changeUser";
            this.changeUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.changeUser.Size = new System.Drawing.Size(243, 22);
            this.changeUser.Text = "Сменить пользователя";
            this.changeUser.Click += new System.EventHandler(this.changeUser_Click);
            // 
            // usersMenu
            // 
            this.usersMenu.Name = "usersMenu";
            this.usersMenu.Size = new System.Drawing.Size(97, 20);
            this.usersMenu.Text = "&Пользователи";
            this.usersMenu.Click += new System.EventHandler(this.usersMenu_Click);
            this.usersMenu.MouseEnter += new System.EventHandler(this.fileMenu_MouseEnter);
            this.usersMenu.MouseLeave += new System.EventHandler(this.fileMenu_MouseLeave);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abouMenu,
            this.userHelpMenu,
            this.HotKeysMenu});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(65, 20);
            this.helpMenu.Text = "&Справка";
            this.helpMenu.MouseEnter += new System.EventHandler(this.fileMenu_MouseEnter);
            this.helpMenu.MouseLeave += new System.EventHandler(this.fileMenu_MouseLeave);
            // 
            // abouMenu
            // 
            this.abouMenu.Name = "abouMenu";
            this.abouMenu.Size = new System.Drawing.Size(180, 22);
            this.abouMenu.Text = "О программе";
            this.abouMenu.Click += new System.EventHandler(this.abouMenu_Click);
            // 
            // userHelpMenu
            // 
            this.userHelpMenu.Name = "userHelpMenu";
            this.userHelpMenu.Size = new System.Drawing.Size(180, 22);
            this.userHelpMenu.Text = "Помощь";
            this.userHelpMenu.Click += new System.EventHandler(this.userHelpMenu_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myProfileToolStrip,
            this.helpToolStripButton,
            this.toolStripSeparator3,
            this.AddToolStripBtn,
            this.EditToolStripBtn,
            this.DeleteToolStripBtn,
            this.toolStripSeparator1,
            this.toolStripOnExcel,
            this.toolStripOnWord,
            this.toolStripOnTxt,
            this.toolStripOnEmail,
            this.toolStripPrint,
            this.toolStripSeparator6,
            this.toolStripGraphic});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 404);
            this.toolStrip1.TabIndex = 2;
            // 
            // myProfileToolStrip
            // 
            this.myProfileToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.myProfileToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("myProfileToolStrip.Image")));
            this.myProfileToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.myProfileToolStrip.Name = "myProfileToolStrip";
            this.myProfileToolStrip.Size = new System.Drawing.Size(21, 22);
            this.myProfileToolStrip.Text = "Мой профиль";
            this.myProfileToolStrip.ToolTipText = "Мой профиль (Ctrl + Y)";
            this.myProfileToolStrip.Click += new System.EventHandler(this.myProfileMenu_Click);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(21, 22);
            this.helpToolStripButton.Text = "Справка";
            this.helpToolStripButton.Click += new System.EventHandler(this.userHelpMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(21, 6);
            // 
            // AddToolStripBtn
            // 
            this.AddToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddToolStripBtn.Image")));
            this.AddToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolStripBtn.Name = "AddToolStripBtn";
            this.AddToolStripBtn.Size = new System.Drawing.Size(21, 22);
            this.AddToolStripBtn.Text = "Добавить запись";
            this.AddToolStripBtn.Click += new System.EventHandler(this.AddToolStripBtn_Click);
            // 
            // EditToolStripBtn
            // 
            this.EditToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditToolStripBtn.Image")));
            this.EditToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditToolStripBtn.Name = "EditToolStripBtn";
            this.EditToolStripBtn.Size = new System.Drawing.Size(21, 22);
            this.EditToolStripBtn.Text = "Изменить запись";
            this.EditToolStripBtn.Click += new System.EventHandler(this.EditToolStripBtn_Click);
            // 
            // DeleteToolStripBtn
            // 
            this.DeleteToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripBtn.Image")));
            this.DeleteToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolStripBtn.Name = "DeleteToolStripBtn";
            this.DeleteToolStripBtn.Size = new System.Drawing.Size(21, 22);
            this.DeleteToolStripBtn.Text = "Удалить запись";
            this.DeleteToolStripBtn.Click += new System.EventHandler(this.DeleteToolStripBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(21, 6);
            // 
            // toolStripOnExcel
            // 
            this.toolStripOnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOnExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOnExcel.Image")));
            this.toolStripOnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOnExcel.Name = "toolStripOnExcel";
            this.toolStripOnExcel.Size = new System.Drawing.Size(21, 22);
            this.toolStripOnExcel.Text = "Экспорт в Excel";
            this.toolStripOnExcel.ToolTipText = "Экспорт в Excel (Ctrl + E)";
            this.toolStripOnExcel.Click += new System.EventHandler(this.exportToExcel);
            // 
            // toolStripOnWord
            // 
            this.toolStripOnWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOnWord.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOnWord.Image")));
            this.toolStripOnWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOnWord.Name = "toolStripOnWord";
            this.toolStripOnWord.Size = new System.Drawing.Size(21, 22);
            this.toolStripOnWord.Text = "Экспорт в Word";
            this.toolStripOnWord.ToolTipText = "Экспорт в Word (Ctrl + W)";
            this.toolStripOnWord.Click += new System.EventHandler(this.exportToWord);
            // 
            // toolStripOnTxt
            // 
            this.toolStripOnTxt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOnTxt.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOnTxt.Image")));
            this.toolStripOnTxt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOnTxt.Name = "toolStripOnTxt";
            this.toolStripOnTxt.Size = new System.Drawing.Size(21, 22);
            this.toolStripOnTxt.Text = "Экспорт в текстовый документ";
            this.toolStripOnTxt.ToolTipText = "Экспорт в текстовый документ (Ctrl + I)";
            this.toolStripOnTxt.Click += new System.EventHandler(this.exportToTXT);
            // 
            // toolStripOnEmail
            // 
            this.toolStripOnEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOnEmail.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOnEmail.Image")));
            this.toolStripOnEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOnEmail.Name = "toolStripOnEmail";
            this.toolStripOnEmail.Size = new System.Drawing.Size(21, 22);
            this.toolStripOnEmail.Text = "Отправка на почту";
            this.toolStripOnEmail.ToolTipText = "Отправка на почту (Ctrl + M)";
            this.toolStripOnEmail.Click += new System.EventHandler(this.sendOnEmail);
            // 
            // toolStripPrint
            // 
            this.toolStripPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPrint.Image")));
            this.toolStripPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPrint.Name = "toolStripPrint";
            this.toolStripPrint.Size = new System.Drawing.Size(21, 22);
            this.toolStripPrint.Text = "&Печать";
            this.toolStripPrint.ToolTipText = "Печать (Ctrl + P)";
            this.toolStripPrint.Click += new System.EventHandler(this.printTable);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(21, 6);
            // 
            // toolStripGraphic
            // 
            this.toolStripGraphic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripGraphic.Image = ((System.Drawing.Image)(resources.GetObject("toolStripGraphic.Image")));
            this.toolStripGraphic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripGraphic.Name = "toolStripGraphic";
            this.toolStripGraphic.Size = new System.Drawing.Size(21, 22);
            this.toolStripGraphic.Text = "График успеваемости";
            this.toolStripGraphic.Click += new System.EventHandler(this.toolStripGraphic_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.treeView1.HotTracking = true;
            this.treeView1.Indent = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.MinimumSize = new System.Drawing.Size(160, 4);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Аспирантура";
            treeNode1.Text = "Аспирантура";
            treeNode2.Name = "Докторские";
            treeNode2.Text = "Докторские";
            treeNode3.Name = "Кандидатские";
            treeNode3.Text = "Кандидатские";
            treeNode4.Name = "НаучныеТемы";
            treeNode4.Text = "Научные темы";
            treeNode5.Name = "НаучныеНаправления";
            treeNode5.Text = "Научные направления";
            treeNode6.Name = "Нагрузки";
            treeNode6.Text = "Нагрузки";
            treeNode7.Name = "Преподаватели";
            treeNode7.Text = "Преподаватели";
            treeNode8.Name = "УчебныеПоручения";
            treeNode8.Text = "Учебные поручения";
            treeNode9.Name = "Кафедры";
            treeNode9.Text = "Кафедры";
            treeNode10.Name = "ДипломныеРаботы";
            treeNode10.Text = "Дипломные работы";
            treeNode11.Name = "Контроль";
            treeNode11.Text = "Контроль";
            treeNode12.Name = "Студенты";
            treeNode12.Text = "Студенты";
            treeNode13.Name = "Группы";
            treeNode13.Text = "Группы";
            treeNode14.Name = "Факультеты";
            treeNode14.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode14.Text = "Факультеты";
            treeNode15.Name = "УчебныеПланы";
            treeNode15.Text = "Учебные планы";
            treeNode16.Name = "Дисциплины";
            treeNode16.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode16.Text = "Дисциплины";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode16});
            this.treeView1.Size = new System.Drawing.Size(168, 184);
            this.treeView1.TabIndex = 3;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.openNewTab);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(24, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(793, 404);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.PropertyPanel);
            this.splitContainer2.Size = new System.Drawing.Size(170, 404);
            this.splitContainer2.SplitterDistance = 186;
            this.splitContainer2.TabIndex = 4;
            // 
            // PropertyPanel
            // 
            this.PropertyPanel.AutoScroll = true;
            this.PropertyPanel.BackColor = System.Drawing.Color.White;
            this.PropertyPanel.Controls.Add(this.checkBox1);
            this.PropertyPanel.Controls.Add(this.comboBox1);
            this.PropertyPanel.Controls.Add(this.label2);
            this.PropertyPanel.Controls.Add(this.textBox1);
            this.PropertyPanel.Controls.Add(this.label1);
            this.PropertyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyPanel.Location = new System.Drawing.Point(0, 0);
            this.PropertyPanel.Name = "PropertyPanel";
            this.PropertyPanel.Size = new System.Drawing.Size(168, 212);
            this.PropertyPanel.TabIndex = 0;
            this.PropertyPanel.SizeChanged += new System.EventHandler(this.panelFacult_SizeChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(15, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Показывать код";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Поиск по...";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.textBox1.Location = new System.Drawing.Point(15, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ничего не выбрано";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(619, 404);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator8,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 98);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem1.Text = "Закрыть";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(125, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem2.Text = "Добавить";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.GreenYellow;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem3.Text = "Изменить";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.Color.Firebrick;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem4.Text = "Удалить";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statNodePath,
            this.empt,
            this.statSelected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(817, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statNodePath
            // 
            this.statNodePath.Name = "statNodePath";
            this.statNodePath.Size = new System.Drawing.Size(45, 17);
            this.statNodePath.Text = "Готово";
            // 
            // empt
            // 
            this.empt.Name = "empt";
            this.empt.Size = new System.Drawing.Size(757, 17);
            this.empt.Spring = true;
            // 
            // statSelected
            // 
            this.statSelected.Name = "statSelected";
            this.statSelected.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statSelected.Size = new System.Drawing.Size(0, 17);
            // 
            // HotKeysMenu
            // 
            this.HotKeysMenu.Name = "HotKeysMenu";
            this.HotKeysMenu.Size = new System.Drawing.Size(180, 22);
            this.HotKeysMenu.Text = "Горячие клавиши";
            this.HotKeysMenu.Click += new System.EventHandler(this.HotKeysMenu_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(790, 400);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESUM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotKeys);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.PropertyPanel.ResumeLayout(false);
            this.PropertyPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem createReport;
        private System.Windows.Forms.ToolStripMenuItem reportOnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem tableMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel PropertyPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem addMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton AddToolStripBtn;
        private System.Windows.Forms.ToolStripButton EditToolStripBtn;
        private System.Windows.Forms.ToolStripButton DeleteToolStripBtn;
        private System.Windows.Forms.ToolStripMenuItem closeAllTabsMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem reportToExcel;
        private System.Windows.Forms.ToolStripMenuItem reportToWord;
        private System.Windows.Forms.ToolStripMenuItem reportToTXT;
        private System.Windows.Forms.ToolStripMenuItem reportOnMail;
        private System.Windows.Forms.ToolStripMenuItem usersMenu;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statNodePath;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem abouMenu;
        private System.Windows.Forms.ToolStripMenuItem userHelpMenu;
        private System.Windows.Forms.ToolStripStatusLabel statSelected;
        private System.Windows.Forms.ToolStripStatusLabel empt;
        private System.Windows.Forms.ToolStripMenuItem changeUser;
        private System.Windows.Forms.ToolStripButton toolStripOnExcel;
        private System.Windows.Forms.ToolStripButton toolStripOnWord;
        private System.Windows.Forms.ToolStripButton toolStripOnTxt;
        private System.Windows.Forms.ToolStripButton toolStripOnEmail;
        private System.Windows.Forms.ToolStripMenuItem myProfileMenu;
        private System.Windows.Forms.ToolStripButton myProfileToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripGraphic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem HotKeysMenu;
    }
}

