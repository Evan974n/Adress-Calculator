namespace SAE_2._03_Réseau
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            rdobtnFiltre = new RadioButton();
            rdobtnReseau = new RadioButton();
            panel27 = new Panel();
            panel28 = new Panel();
            lblMasquedesousreseau = new Label();
            panel24 = new Panel();
            panel25 = new Panel();
            lblDmachine = new Label();
            panel22 = new Panel();
            panel23 = new Panel();
            lblPmachine = new Label();
            panel20 = new Panel();
            panel21 = new Panel();
            lblMasqueB = new Label();
            panel18 = new Panel();
            panel19 = new Panel();
            lblnbMachine = new Label();
            panel16 = new Panel();
            panel17 = new Panel();
            lblBroadcast = new Label();
            panel10 = new Panel();
            panel15 = new Panel();
            lblReseau = new Label();
            button1 = new Button();
            panel9 = new Panel();
            panel14 = new Panel();
            lblIPB = new Label();
            panel12 = new Panel();
            panel13 = new Panel();
            lblClasse = new Label();
            pnlAdresseIP = new Panel();
            panel11 = new Panel();
            lblAdresseIP = new Label();
            btbnCalculer = new Button();
            pnlbarre = new Panel();
            panel26 = new Panel();
            lblOU = new Label();
            label2 = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            txtboxMasque = new TextBox();
            panel7 = new Panel();
            panel8 = new Panel();
            txtboxIP2 = new TextBox();
            lblslash = new Label();
            panel4 = new Panel();
            pnlCIDR = new Panel();
            txtboxCIDR = new TextBox();
            panel3 = new Panel();
            panel2 = new Panel();
            txtboxIP = new TextBox();
            label1 = new Label();
            Btnretour = new Button();
            pnlB = new Panel();
            panel1.SuspendLayout();
            panel27.SuspendLayout();
            panel28.SuspendLayout();
            panel24.SuspendLayout();
            panel25.SuspendLayout();
            panel22.SuspendLayout();
            panel23.SuspendLayout();
            panel20.SuspendLayout();
            panel21.SuspendLayout();
            panel18.SuspendLayout();
            panel19.SuspendLayout();
            panel16.SuspendLayout();
            panel17.SuspendLayout();
            panel10.SuspendLayout();
            panel15.SuspendLayout();
            panel9.SuspendLayout();
            panel14.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            pnlAdresseIP.SuspendLayout();
            panel11.SuspendLayout();
            pnlbarre.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel4.SuspendLayout();
            pnlCIDR.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(218, 192, 163);
            panel1.Controls.Add(rdobtnFiltre);
            panel1.Controls.Add(rdobtnReseau);
            panel1.Controls.Add(panel27);
            panel1.Controls.Add(panel24);
            panel1.Controls.Add(panel22);
            panel1.Controls.Add(panel20);
            panel1.Controls.Add(panel18);
            panel1.Controls.Add(panel16);
            panel1.Controls.Add(panel10);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(panel12);
            panel1.Controls.Add(pnlAdresseIP);
            panel1.Controls.Add(btbnCalculer);
            panel1.Controls.Add(pnlbarre);
            panel1.Controls.Add(lblOU);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(lblslash);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Btnretour);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(887, 1187);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // rdobtnFiltre
            // 
            rdobtnFiltre.AutoSize = true;
            rdobtnFiltre.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdobtnFiltre.ForeColor = Color.FromArgb(16, 44, 87);
            rdobtnFiltre.Location = new Point(357, 1074);
            rdobtnFiltre.Name = "rdobtnFiltre";
            rdobtnFiltre.Size = new Size(129, 25);
            rdobtnFiltre.TabIndex = 27;
            rdobtnFiltre.Text = "Mode filtre";
            rdobtnFiltre.UseVisualStyleBackColor = true;
            rdobtnFiltre.CheckedChanged += rdobtnFiltre_CheckedChanged;
            // 
            // rdobtnReseau
            // 
            rdobtnReseau.AccessibleRole = AccessibleRole.Window;
            rdobtnReseau.AutoSize = true;
            rdobtnReseau.Checked = true;
            rdobtnReseau.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdobtnReseau.ForeColor = Color.FromArgb(16, 44, 87);
            rdobtnReseau.Location = new Point(357, 1043);
            rdobtnReseau.Name = "rdobtnReseau";
            rdobtnReseau.Size = new Size(150, 25);
            rdobtnReseau.TabIndex = 26;
            rdobtnReseau.TabStop = true;
            rdobtnReseau.Text = "Mode réseau";
            rdobtnReseau.UseVisualStyleBackColor = true;
            rdobtnReseau.CheckedChanged += rdobtnReseau_CheckedChanged;
            // 
            // panel27
            // 
            panel27.BackColor = Color.FromArgb(16, 44, 87);
            panel27.Controls.Add(panel28);
            panel27.Location = new Point(113, 429);
            panel27.Name = "panel27";
            panel27.Size = new Size(644, 50);
            panel27.TabIndex = 17;
            // 
            // panel28
            // 
            panel28.AutoSize = true;
            panel28.BackColor = Color.FromArgb(234, 219, 200);
            panel28.Controls.Add(lblMasquedesousreseau);
            panel28.Location = new Point(3, 3);
            panel28.Name = "panel28";
            panel28.Size = new Size(638, 44);
            panel28.TabIndex = 5;
            // 
            // lblMasquedesousreseau
            // 
            lblMasquedesousreseau.AutoSize = true;
            lblMasquedesousreseau.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblMasquedesousreseau.ForeColor = Color.FromArgb(16, 44, 87);
            lblMasquedesousreseau.Location = new Point(3, 13);
            lblMasquedesousreseau.Name = "lblMasquedesousreseau";
            lblMasquedesousreseau.Size = new Size(238, 21);
            lblMasquedesousreseau.TabIndex = 22;
            lblMasquedesousreseau.Text = "Masque de sous réseau...";
            // 
            // panel24
            // 
            panel24.BackColor = Color.FromArgb(16, 44, 87);
            panel24.Controls.Add(panel25);
            panel24.Location = new Point(113, 974);
            panel24.Name = "panel24";
            panel24.Size = new Size(644, 50);
            panel24.TabIndex = 19;
            // 
            // panel25
            // 
            panel25.AutoSize = true;
            panel25.BackColor = Color.FromArgb(234, 219, 200);
            panel25.Controls.Add(lblDmachine);
            panel25.Location = new Point(3, 3);
            panel25.Name = "panel25";
            panel25.Size = new Size(638, 44);
            panel25.TabIndex = 5;
            // 
            // lblDmachine
            // 
            lblDmachine.AutoSize = true;
            lblDmachine.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDmachine.ForeColor = Color.FromArgb(16, 44, 87);
            lblDmachine.Location = new Point(3, 12);
            lblDmachine.Name = "lblDmachine";
            lblDmachine.Size = new Size(129, 21);
            lblDmachine.TabIndex = 29;
            lblDmachine.Text = "Dernière IP...";
            // 
            // panel22
            // 
            panel22.BackColor = Color.FromArgb(16, 44, 87);
            panel22.Controls.Add(panel23);
            panel22.Location = new Point(113, 898);
            panel22.Name = "panel22";
            panel22.Size = new Size(644, 50);
            panel22.TabIndex = 19;
            // 
            // panel23
            // 
            panel23.AutoSize = true;
            panel23.BackColor = Color.FromArgb(234, 219, 200);
            panel23.Controls.Add(lblPmachine);
            panel23.Location = new Point(3, 3);
            panel23.Name = "panel23";
            panel23.Size = new Size(638, 44);
            panel23.TabIndex = 5;
            // 
            // lblPmachine
            // 
            lblPmachine.AutoSize = true;
            lblPmachine.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPmachine.ForeColor = Color.FromArgb(16, 44, 87);
            lblPmachine.Location = new Point(3, 11);
            lblPmachine.Name = "lblPmachine";
            lblPmachine.Size = new Size(133, 21);
            lblPmachine.TabIndex = 28;
            lblPmachine.Text = "Première IP...";
            // 
            // panel20
            // 
            panel20.BackColor = Color.FromArgb(16, 44, 87);
            panel20.Controls.Add(panel21);
            panel20.Location = new Point(113, 593);
            panel20.Name = "panel20";
            panel20.Size = new Size(644, 50);
            panel20.TabIndex = 17;
            // 
            // panel21
            // 
            panel21.AutoSize = true;
            panel21.BackColor = Color.FromArgb(234, 219, 200);
            panel21.Controls.Add(lblMasqueB);
            panel21.Location = new Point(3, 3);
            panel21.Name = "panel21";
            panel21.Size = new Size(638, 44);
            panel21.TabIndex = 5;
            // 
            // lblMasqueB
            // 
            lblMasqueB.AutoSize = true;
            lblMasqueB.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblMasqueB.ForeColor = Color.FromArgb(16, 44, 87);
            lblMasqueB.Location = new Point(3, 14);
            lblMasqueB.Name = "lblMasqueB";
            lblMasqueB.Size = new Size(178, 21);
            lblMasqueB.TabIndex = 24;
            lblMasqueB.Text = "Masque (Binaire)...";
            // 
            // panel18
            // 
            panel18.BackColor = Color.FromArgb(16, 44, 87);
            panel18.Controls.Add(panel19);
            panel18.Location = new Point(113, 823);
            panel18.Name = "panel18";
            panel18.Size = new Size(644, 50);
            panel18.TabIndex = 18;
            // 
            // panel19
            // 
            panel19.AutoSize = true;
            panel19.BackColor = Color.FromArgb(234, 219, 200);
            panel19.Controls.Add(lblnbMachine);
            panel19.Location = new Point(3, 3);
            panel19.Name = "panel19";
            panel19.Size = new Size(638, 44);
            panel19.TabIndex = 5;
            // 
            // lblnbMachine
            // 
            lblnbMachine.AutoSize = true;
            lblnbMachine.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblnbMachine.ForeColor = Color.FromArgb(16, 44, 87);
            lblnbMachine.Location = new Point(3, 13);
            lblnbMachine.Name = "lblnbMachine";
            lblnbMachine.Size = new Size(137, 21);
            lblnbMachine.TabIndex = 27;
            lblnbMachine.Text = "Nombre d'IP...";
            // 
            // panel16
            // 
            panel16.BackColor = Color.FromArgb(16, 44, 87);
            panel16.Controls.Add(panel17);
            panel16.Location = new Point(113, 748);
            panel16.Name = "panel16";
            panel16.Size = new Size(644, 50);
            panel16.TabIndex = 17;
            // 
            // panel17
            // 
            panel17.AutoSize = true;
            panel17.BackColor = Color.FromArgb(234, 219, 200);
            panel17.Controls.Add(lblBroadcast);
            panel17.Location = new Point(3, 3);
            panel17.Name = "panel17";
            panel17.Size = new Size(638, 44);
            panel17.TabIndex = 5;
            // 
            // lblBroadcast
            // 
            lblBroadcast.AutoSize = true;
            lblBroadcast.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBroadcast.ForeColor = Color.FromArgb(16, 44, 87);
            lblBroadcast.Location = new Point(3, 14);
            lblBroadcast.Name = "lblBroadcast";
            lblBroadcast.Size = new Size(199, 21);
            lblBroadcast.TabIndex = 26;
            lblBroadcast.Text = "Adresse Broadcast...";
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(16, 44, 87);
            panel10.Controls.Add(panel15);
            panel10.Location = new Point(113, 672);
            panel10.Name = "panel10";
            panel10.Size = new Size(644, 50);
            panel10.TabIndex = 17;
            // 
            // panel15
            // 
            panel15.AutoSize = true;
            panel15.BackColor = Color.FromArgb(234, 219, 200);
            panel15.Controls.Add(lblReseau);
            panel15.Location = new Point(3, 3);
            panel15.Name = "panel15";
            panel15.Size = new Size(638, 44);
            panel15.TabIndex = 5;
            // 
            // lblReseau
            // 
            lblReseau.AutoSize = true;
            lblReseau.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblReseau.ForeColor = Color.FromArgb(16, 44, 87);
            lblReseau.Location = new Point(3, 12);
            lblReseau.Name = "lblReseau";
            lblReseau.Size = new Size(174, 21);
            lblReseau.TabIndex = 25;
            lblReseau.Text = "Adresse Reseau...";
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(16, 44, 87);
            button1.Location = new Point(31, 24);
            button1.Name = "button1";
            button1.Size = new Size(26, 39);
            button1.TabIndex = 17;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(16, 44, 87);
            panel9.Controls.Add(panel14);
            panel9.Location = new Point(113, 512);
            panel9.Name = "panel9";
            panel9.Size = new Size(644, 50);
            panel9.TabIndex = 16;
            // 
            // panel14
            // 
            panel14.AutoSize = true;
            panel14.BackColor = Color.FromArgb(234, 219, 200);
            panel14.Controls.Add(lblIPB);
            panel14.Location = new Point(3, 3);
            panel14.Name = "panel14";
            panel14.Size = new Size(638, 44);
            panel14.TabIndex = 5;
            // 
            // lblIPB
            // 
            lblIPB.AutoSize = true;
            lblIPB.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIPB.ForeColor = Color.FromArgb(16, 44, 87);
            lblIPB.Location = new Point(3, 13);
            lblIPB.Name = "lblIPB";
            lblIPB.Size = new Size(206, 21);
            lblIPB.TabIndex = 23;
            lblIPB.Text = "Adresse IP (Binaire)...";
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(16, 44, 87);
            panel12.Controls.Add(panel13);
            panel12.Location = new Point(498, 349);
            panel12.Name = "panel12";
            panel12.Size = new Size(259, 50);
            panel12.TabIndex = 16;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(234, 219, 200);
            panel13.Controls.Add(lblClasse);
            panel13.Location = new Point(3, 3);
            panel13.Name = "panel13";
            panel13.Size = new Size(253, 44);
            panel13.TabIndex = 8;
            // 
            // lblClasse
            // 
            lblClasse.AutoSize = true;
            lblClasse.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblClasse.ForeColor = Color.FromArgb(16, 44, 87);
            lblClasse.Location = new Point(9, 13);
            lblClasse.Name = "lblClasse";
            lblClasse.Size = new Size(88, 21);
            lblClasse.TabIndex = 21;
            lblClasse.Text = "Classe...";
            // 
            // pnlAdresseIP
            // 
            pnlAdresseIP.BackColor = Color.FromArgb(16, 44, 87);
            pnlAdresseIP.Controls.Add(panel11);
            pnlAdresseIP.Location = new Point(113, 349);
            pnlAdresseIP.Name = "pnlAdresseIP";
            pnlAdresseIP.Size = new Size(365, 50);
            pnlAdresseIP.TabIndex = 15;
            // 
            // panel11
            // 
            panel11.AutoSize = true;
            panel11.BackColor = Color.FromArgb(234, 219, 200);
            panel11.Controls.Add(lblAdresseIP);
            panel11.Location = new Point(3, 3);
            panel11.Name = "panel11";
            panel11.Size = new Size(360, 44);
            panel11.TabIndex = 5;
            // 
            // lblAdresseIP
            // 
            lblAdresseIP.AutoSize = true;
            lblAdresseIP.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblAdresseIP.ForeColor = Color.FromArgb(16, 44, 87);
            lblAdresseIP.Location = new Point(3, 13);
            lblAdresseIP.Name = "lblAdresseIP";
            lblAdresseIP.Size = new Size(125, 21);
            lblAdresseIP.TabIndex = 20;
            lblAdresseIP.Text = "Adresse IP...";
            // 
            // btbnCalculer
            // 
            btbnCalculer.BackColor = Color.FromArgb(234, 219, 200);
            btbnCalculer.FlatAppearance.BorderSize = 3;
            btbnCalculer.FlatStyle = FlatStyle.Flat;
            btbnCalculer.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btbnCalculer.ForeColor = Color.FromArgb(16, 44, 87);
            btbnCalculer.Location = new Point(357, 1124);
            btbnCalculer.Name = "btbnCalculer";
            btbnCalculer.Size = new Size(154, 47);
            btbnCalculer.TabIndex = 14;
            btbnCalculer.Text = "Calculer";
            btbnCalculer.UseVisualStyleBackColor = false;
            btbnCalculer.Click += btbnCalculer_Click;
            // 
            // pnlbarre
            // 
            pnlbarre.BackColor = Color.FromArgb(16, 44, 87);
            pnlbarre.Controls.Add(panel26);
            pnlbarre.Location = new Point(31, 301);
            pnlbarre.Margin = new Padding(2);
            pnlbarre.Name = "pnlbarre";
            pnlbarre.Size = new Size(835, 5);
            pnlbarre.TabIndex = 13;
            // 
            // panel26
            // 
            panel26.BackColor = Color.FromArgb(16, 44, 87);
            panel26.Location = new Point(0, 0);
            panel26.Margin = new Padding(2);
            panel26.Name = "panel26";
            panel26.Size = new Size(835, 5);
            panel26.TabIndex = 14;
            // 
            // lblOU
            // 
            lblOU.AutoSize = true;
            lblOU.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblOU.ForeColor = Color.FromArgb(16, 44, 87);
            lblOU.Location = new Point(430, 179);
            lblOU.Name = "lblOU";
            lblOU.Size = new Size(40, 28);
            lblOU.TabIndex = 12;
            lblOU.Text = "ou";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(16, 44, 87);
            label2.Location = new Point(430, 221);
            label2.Name = "label2";
            label2.Size = new Size(22, 32);
            label2.TabIndex = 11;
            label2.Text = "/";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(16, 44, 87);
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(458, 214);
            panel5.Name = "panel5";
            panel5.Size = new Size(308, 50);
            panel5.TabIndex = 10;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(234, 219, 200);
            panel6.Controls.Add(txtboxMasque);
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(302, 44);
            panel6.TabIndex = 8;
            // 
            // txtboxMasque
            // 
            txtboxMasque.BackColor = Color.FromArgb(234, 219, 200);
            txtboxMasque.BorderStyle = BorderStyle.None;
            txtboxMasque.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxMasque.ForeColor = Color.FromArgb(16, 44, 87);
            txtboxMasque.Location = new Point(9, 13);
            txtboxMasque.Name = "txtboxMasque";
            txtboxMasque.PlaceholderText = "Masque...";
            txtboxMasque.Size = new Size(229, 21);
            txtboxMasque.TabIndex = 0;
            txtboxMasque.TextChanged += textBox1_TextChanged_2;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(16, 44, 87);
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(113, 214);
            panel7.Name = "panel7";
            panel7.Size = new Size(311, 50);
            panel7.TabIndex = 9;
            // 
            // panel8
            // 
            panel8.AutoSize = true;
            panel8.BackColor = Color.FromArgb(234, 219, 200);
            panel8.Controls.Add(txtboxIP2);
            panel8.Location = new Point(3, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(305, 44);
            panel8.TabIndex = 5;
            // 
            // txtboxIP2
            // 
            txtboxIP2.AccessibleDescription = "";
            txtboxIP2.AccessibleName = "";
            txtboxIP2.BackColor = Color.FromArgb(234, 219, 200);
            txtboxIP2.BorderStyle = BorderStyle.None;
            txtboxIP2.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxIP2.ForeColor = Color.FromArgb(16, 44, 87);
            txtboxIP2.Location = new Point(3, 13);
            txtboxIP2.Name = "txtboxIP2";
            txtboxIP2.PlaceholderText = "IPV4...";
            txtboxIP2.Size = new Size(276, 21);
            txtboxIP2.TabIndex = 4;
            // 
            // lblslash
            // 
            lblslash.AutoSize = true;
            lblslash.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblslash.ForeColor = Color.FromArgb(16, 44, 87);
            lblslash.Location = new Point(482, 133);
            lblslash.Name = "lblslash";
            lblslash.Size = new Size(22, 32);
            lblslash.TabIndex = 8;
            lblslash.Text = "/";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(16, 44, 87);
            panel4.Controls.Add(pnlCIDR);
            panel4.Location = new Point(510, 126);
            panel4.Name = "panel4";
            panel4.Size = new Size(259, 50);
            panel4.TabIndex = 7;
            // 
            // pnlCIDR
            // 
            pnlCIDR.BackColor = Color.FromArgb(234, 219, 200);
            pnlCIDR.Controls.Add(txtboxCIDR);
            pnlCIDR.Location = new Point(3, 3);
            pnlCIDR.Name = "pnlCIDR";
            pnlCIDR.Size = new Size(253, 44);
            pnlCIDR.TabIndex = 8;
            // 
            // txtboxCIDR
            // 
            txtboxCIDR.BackColor = Color.FromArgb(234, 219, 200);
            txtboxCIDR.BorderStyle = BorderStyle.None;
            txtboxCIDR.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxCIDR.ForeColor = Color.FromArgb(16, 44, 87);
            txtboxCIDR.Location = new Point(6, 13);
            txtboxCIDR.Name = "txtboxCIDR";
            txtboxCIDR.PlaceholderText = "CIDR...";
            txtboxCIDR.Size = new Size(229, 21);
            txtboxCIDR.TabIndex = 0;
            txtboxCIDR.TextChanged += textBox1_TextChanged_1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(16, 44, 87);
            panel3.Controls.Add(panel2);
            panel3.Location = new Point(113, 126);
            panel3.Name = "panel3";
            panel3.Size = new Size(365, 50);
            panel3.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.BackColor = Color.FromArgb(234, 219, 200);
            panel2.Controls.Add(txtboxIP);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(360, 44);
            panel2.TabIndex = 5;
            // 
            // txtboxIP
            // 
            txtboxIP.AccessibleDescription = "";
            txtboxIP.AccessibleName = "";
            txtboxIP.BackColor = Color.FromArgb(234, 219, 200);
            txtboxIP.BorderStyle = BorderStyle.None;
            txtboxIP.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxIP.ForeColor = Color.FromArgb(16, 44, 87);
            txtboxIP.Location = new Point(3, 13);
            txtboxIP.Name = "txtboxIP";
            txtboxIP.PlaceholderText = "IPV4...";
            txtboxIP.Size = new Size(354, 21);
            txtboxIP.TabIndex = 4;
            txtboxIP.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(16, 44, 87);
            label1.Location = new Point(237, 28);
            label1.Name = "label1";
            label1.Size = new Size(435, 32);
            label1.TabIndex = 2;
            label1.Text = "Calculateur de masque réseau";
            // 
            // Btnretour
            // 
            Btnretour.FlatAppearance.BorderSize = 0;
            Btnretour.FlatStyle = FlatStyle.Flat;
            Btnretour.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Btnretour.ForeColor = Color.FromArgb(16, 44, 87);
            Btnretour.Location = new Point(821, 24);
            Btnretour.Name = "Btnretour";
            Btnretour.Size = new Size(45, 46);
            Btnretour.TabIndex = 1;
            Btnretour.Text = "X";
            Btnretour.UseVisualStyleBackColor = true;
            Btnretour.Click += Btnretour_Click;
            // 
            // pnlB
            // 
            pnlB.BackColor = Color.Transparent;
            pnlB.Location = new Point(12, 1);
            pnlB.Name = "pnlB";
            pnlB.Size = new Size(884, 81);
            pnlB.TabIndex = 15;
            pnlB.MouseDown += pnlB_MouseDown;
            pnlB.MouseMove += pnlB_MouseMove;
            pnlB.MouseUp += pnlB_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 44, 87);
            ClientSize = new Size(911, 1211);
            Controls.Add(panel1);
            Controls.Add(pnlB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Calculateur de masque réseau";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel27.ResumeLayout(false);
            panel27.PerformLayout();
            panel28.ResumeLayout(false);
            panel28.PerformLayout();
            panel24.ResumeLayout(false);
            panel24.PerformLayout();
            panel25.ResumeLayout(false);
            panel25.PerformLayout();
            panel22.ResumeLayout(false);
            panel22.PerformLayout();
            panel23.ResumeLayout(false);
            panel23.PerformLayout();
            panel20.ResumeLayout(false);
            panel20.PerformLayout();
            panel21.ResumeLayout(false);
            panel21.PerformLayout();
            panel18.ResumeLayout(false);
            panel18.PerformLayout();
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel12.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            pnlAdresseIP.ResumeLayout(false);
            pnlAdresseIP.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            pnlbarre.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel4.ResumeLayout(false);
            pnlCIDR.ResumeLayout(false);
            pnlCIDR.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Btnretour;
        private Label label1;
        private Panel panel2;
        private TextBox txtboxIP;
        private Panel panel3;
        private Panel panel4;
        private Panel pnlCIDR;
        private TextBox txtboxCIDR;
        private Label lblslash;
        private Label lblOU;
        private Label label2;
        private Panel panel5;
        private Panel panel6;
        private TextBox txtboxMasque;
        private Panel panel7;
        private Panel panel8;
        private TextBox txtboxIP2;
        private Panel pnlbarre;
        private Button btbnCalculer;
        private Panel pnlB;
        private Panel panel12;
        private Panel panel13;
        private Panel pnlAdresseIP;
        private Panel panel11;
        private Panel panel9;
        private Panel panel14;
        private Button button1;
        private Panel panel18;
        private Panel panel19;
        private Panel panel16;
        private Panel panel17;
        private Panel panel10;
        private Panel panel15;
        private Panel panel20;
        private Panel panel21;
        private Panel panel26;
        private Panel panel24;
        private Panel panel25;
        private Panel panel22;
        private Panel panel23;
        private Panel panel27;
        private Panel panel28;
        private Label lblAdresseIP;
        private Label lblMasquedesousreseau;
        private Label lblDmachine;
        private Label lblPmachine;
        private Label lblMasqueB;
        private Label lblnbMachine;
        private Label lblBroadcast;
        private Label lblReseau;
        private Label lblIPB;
        private Label lblClasse;
        private RadioButton rdobtnFiltre;
        private RadioButton rdobtnReseau;
    }
}