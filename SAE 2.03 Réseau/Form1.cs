using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace SAE_2._03_Réseau
{
    public partial class Form1 : Form
    {
        // Déclarez des variables pour stocker les valeurs initiales des labels
        private string initialClasseText;
        private string initialAdresseIPText;
        private string initialMasqueText;
        private string initialReseauText;
        private string initialBroadcastText;
        private string initialNbMachineText;
        private string initialIPBText;
        private string initialMasqueBText;
        private string initialPmachineText;
        private string initialDmachineText;
        private string initialCIDRText;
        private string initialNbMachinesText;
        private Point startPoint;

        private readonly List<(string Start, string End, string Description)> specialIPRanges = new List<(string, string, string)>
        {
            ("0.0.0.0", "0.255.255.255", "\"This\" Network RFC 1122, Section 3.2.1.3"),
            ("10.0.0.0", "10.255.255.255", "Private-Use Networks RFC 1918"),
            ("127.0.0.0", "127.255.255.255", "Loopback RFC 1122, Section 3.2.1.3"),
            ("169.254.0.0", "169.254.255.255", "Link Local RFC 3927"),
            ("172.16.0.0", "172.31.255.255", "Private-Use Networks RFC 1918"),
            ("192.0.0.0", "192.0.0.255", "IETF Protocol Assignments RFC 5736"),
            ("192.0.2.0", "192.0.2.255", "TEST-NET-1 RFC 5737"),
            ("192.88.99.0", "192.88.99.255", "6to4 Relay Anycast RFC 3068"),
            ("192.168.0.0", "192.168.255.255", "Private-Use Networks RFC 1918"),
            ("198.18.0.0", "198.19.255.255", "Network Interconnect Device Benchmark Testing RFC 2544"),
            ("198.51.100.0", "198.51.100.255", "TEST-NET-2 RFC 5737"),
            ("203.0.113.0", "203.0.113.255", "TEST-NET-3 RFC 5737"),
            ("224.0.0.0", "239.255.255.255", "Multicast RFC 3171"),
            ("240.0.0.0", "255.255.255.255", "Reserved for Future Use RFC 1112, Section 4"),
            ("100.64.0.0", "100.127.255.255", "CGN RFC6598")
        };

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;

            // Stockez les valeurs initiales des labels
            initialClasseText = lblClasse.Text;
            initialAdresseIPText = lblAdresseIP.Text;
            initialMasqueText = lblMasquedesousreseau.Text;
            initialReseauText = lblReseau.Text;
            initialBroadcastText = lblBroadcast.Text;
            initialNbMachineText = lblnbIP.Text;
            initialIPBText = lblIPB.Text;
            initialMasqueBText = lblMasqueB.Text;
            initialPmachineText = lblPmachine.Text;
            initialDmachineText = lblDmachine.Text;
            initialCIDRText = lblCIDR.Text; // Sauvegarder la valeur initiale de lblCIDR
            initialNbMachinesText = lblNbMachines.Text;
        }

        private void Btnretour_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private static string ObtenirClasseIP(string ipAddress)
        {

            // Séparer les octets de l'adresse IP
            string[] octets = ipAddress.Split('.');
            int firstOctet = int.Parse(octets[0]);

            if (firstOctet >= 0 && firstOctet <= 127)
            {
                return "A";
            }
            else if (firstOctet >= 128 && firstOctet <= 191)
            {
                return "B";
            }
            else if (firstOctet >= 192 && firstOctet <= 223)
            {
                return "C";
            }
            else if (firstOctet >= 224 && firstOctet <= 239)
            {
                return "D";
            }
            else if (firstOctet >= 240 && firstOctet <= 255)
            {
                return "E";
            }
            else
            {
                return "Inconnue";
            }
        }





        private void btbnCalculer_Click(object sender, EventArgs e)
        {
            try
            {
                string masqueInput = txtboxMasque.Text;
                string ip2Input = txtboxIP2.Text;
                string cidrInput = txtboxCIDR.Text;
                string ipInput = txtboxIP.Text;

                // Vérifier si les champs IP1 et CIDR sont remplis
                bool isIPAndCIDRProvided = !string.IsNullOrWhiteSpace(ipInput) && !string.IsNullOrWhiteSpace(cidrInput);

                // Vérifier si les champs IP2 et Masque sont remplis
                bool isIP2AndMasqueProvided = !string.IsNullOrWhiteSpace(ip2Input) && !string.IsNullOrWhiteSpace(masqueInput);

                // Vérifier si les deux ensembles de champs sont remplis
                if (isIPAndCIDRProvided && isIP2AndMasqueProvided)
                {
                    MessageBox.Show("Veuillez remplir soit les champs IP1 et CIDR, soit les champs IP2 et Masque, mais pas les deux ensembles.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier si des champs supplémentaires sont remplis
                if (isIPAndCIDRProvided && (!string.IsNullOrWhiteSpace(ip2Input) || !string.IsNullOrWhiteSpace(masqueInput)))
                {
                    MessageBox.Show("Si vous remplissez les champs IP1 et CIDR, veuillez laisser les champs IP2 et Masque vides.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (isIP2AndMasqueProvided && (!string.IsNullOrWhiteSpace(ipInput) || !string.IsNullOrWhiteSpace(cidrInput)))
                {
                    MessageBox.Show("Si vous remplissez les champs IP2 et Masque, veuillez laisser les champs IP1 et CIDR vides.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (isIPAndCIDRProvided)
                {
                    // Valider IP et CIDR
                    if (!ValidationIP(ipInput))
                    {
                        MessageBox.Show("Le format de l'adresse IP est invalide. Veuillez entrer une adresse IP valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (!ValidationCIDR(cidrInput))
                    {
                        MessageBox.Show("Le format du CIDR est invalide. Veuillez entrer un CIDR valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Vérifier la correspondance du CIDR avec la classe de l'IP
                    string ipClass = ObtenirClasseIP(ipInput);
                    int cidrValue = int.Parse(cidrInput);

                    if (!ValidationCIDRPourClasse(ipClass, cidrValue))
                    {
                        MessageBox.Show($"Le CIDR {cidrValue} n'est pas valide pour une adresse IP de classe {ipClass}.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Vérifier si l'adresse IP appartient à une plage spéciale
                    if (IPSpeciale(ipInput, out string? specialMessage))
                    {
                        MessageBox.Show(specialMessage, "Adresse IP spéciale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Si validation réussie, calculer et afficher la classe IP et le masque de sous-réseau
                    AfficherClasseIPetMasque(ipInput, cidrValue);

                    // Affecter la valeur du CIDR à lblCIDR
                    lblCIDR.Text = $"CIDR : {cidrInput}";
                }
                else if (isIP2AndMasqueProvided)
                {
                    // Valider IP2
                    if (!ValidationIP(ip2Input))
                    {
                        MessageBox.Show("Le format de l'adresse IP secondaire est invalide. Veuillez entrer une adresse IP valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Valider le masque de sous-réseau
                    if (!ValidationIP(masqueInput))
                    {
                        MessageBox.Show("Le format du masque de sous-réseau est invalide. Veuillez entrer un masque de sous-réseau valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Vérifier si l'adresse IP2 appartient à une plage spéciale
                    if (IPSpeciale(ip2Input, out string? specialMessage))
                    {
                        MessageBox.Show(specialMessage, "Adresse IP spéciale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Convertir le masque en octets et valider
                    byte[] masqueBytes = masqueInput.Split('.').Select(byte.Parse).ToArray();
                    if (!ValidationMasqueReseau(masqueBytes))
                    {
                        MessageBox.Show("Le masque de sous-réseau n'est pas valide. Veuillez entrer un masque de sous-réseau continu.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Affecter le CIDR correspondant au masque à lblCIDR
                    lblCIDR.Text = $"CIDR : {CalculerCIDRDepuisMasque(masqueBytes).ToString()}";

                    // Vérifier la correspondance du masque avec la classe de l'IP
                    string ipClass = ObtenirClasseIP(ip2Input);
                    if (!ValidationMasquePourClasse(ipClass, masqueBytes))
                    {
                        MessageBox.Show($"Le masque de sous-réseau {masqueInput} n'est pas valide pour une adresse IP de classe {ipClass}.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Si validation réussie, calculer et afficher la classe IP pour ip2Input
                    AfficherClasseIPetMasque(ip2Input, CalculerCIDRDepuisMasque(masqueBytes));

                    // Autres opérations ...
                }
                else
                {
                    MessageBox.Show("Veuillez remplir soit les champs IP1 et CIDR, soit les champs IP2 et Masque.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private bool ValidationMasquePourClasse(string ipClass, byte[] maskBytes)
        {
            string mask = string.Join(".", maskBytes.Select(b => b.ToString()));

            switch (ipClass)
            {
                case "A":
                    if ((mask.CompareTo("255.0.0.0") >= 0 && mask.CompareTo("255.255.255.255") <= 0))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "B":
                    if ((mask.CompareTo("255.255.0.0") >= 0 && mask.CompareTo("255.255.255.255") <= 0))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "C":
                    if ((mask.CompareTo("255.255.255.0") >= 0 && mask.CompareTo("255.255.255.255") <= 0))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "D":
                    if ((mask.CompareTo("255.255.255.0") >= 0 && mask.CompareTo("255.255.255.240") <= 0) || mask == "255.255.255.255")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "E":
                    if (mask == "255.255.255.255")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }



        private int CalculerCIDRDepuisMasque(byte[] maskBytes)
        {
            int cidr = 0;
            foreach (byte b in maskBytes)
            {
                cidr += Convert.ToString(b, 2).Count(bit => bit == '1');
            }
            return cidr;
        }





        private bool ValidationCIDRPourClasse(string ipClass, int cidr)
        {
            // Définir les plages CIDR valides pour chaque classe d'IP
            switch (ipClass)
            {
                case "A":
                    return cidr >= 8 && cidr <= 32;
                case "B":
                    return cidr >= 16 && cidr <= 32;
                case "C":
                    return cidr >= 24 && cidr <= 32;
                case "D":
                    return cidr >= 24 && cidr <= 32;
                case "E":
                    return cidr >= 24 && cidr == 32;
                default:
                    return false;
            }
        }




        private bool ValidationMasqueReseau(byte[] maskBytes)
        {
            // Convertir le masque en une chaîne de bits
            StringBuilder binaryMask = new StringBuilder();
            foreach (byte b in maskBytes)
            {
                binaryMask.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            // Vérifier si la chaîne de bits est continue
            bool foundZero = false;
            for (int i = 0; i < binaryMask.Length; i++)
            {
                if (binaryMask[i] == '0')
                {
                    foundZero = true;
                }
                else if (foundZero)
                {
                    // S'il y a un zéro après qu'on ait trouvé un zéro précédemment,
                    // le masque n'est pas valide
                    return false;
                }
            }

            return true;
        }


        private void AfficherClasseIPetMasque(string ipAddress, int cidr)
        {
            if (ValidationIP(ipAddress))
            {
                // Calculer la classe IP
                string ipClass = ObtenirClasseIP(ipAddress);
                // Calculer le masque de sous-réseau
                string subnetMask = ObtenirMasque(cidr);
                // Afficher la classe IP dans le label
                lblClasse.Text = $"Classe IP : {ipClass}";
                // Copier l'adresse IP dans le label lblAdresseIP
                lblAdresseIP.Text = $"Adresse IP : {ipAddress}";
                // Afficher le masque de sous-réseau dans le label lblMasque
                lblMasquedesousreseau.Text = $"Masque de sous-réseau : {subnetMask}";
                // Afficher l'adresse IP en binaire
                lblIPB.Text = $"Adresse IP (Binaire) : {EnBinaire(ipAddress)}";
                // Afficher l'adresse masque en binaire
                lblMasqueB.Text = $"Adresse masque (Binaire) : {EnBinaire(subnetMask)}";

                // Calculer et afficher l'adresse réseau
                string adresseReseau = CalculerAdresseReseau(ipAddress, subnetMask);
                lblReseau.Text = $"Adresse réseau : {adresseReseau}";

                // Calculer et afficher la première adresse IP dans le mode réseau
                string premiereIPReseau = CalculerPremiereAdresseIPReseau(adresseReseau, cidr);
                lblPmachine.Text = $"Première IP : {premiereIPReseau}";

                // Calculer et afficher l'adresse de broadcast
                string adresseBroadcast = CalculerAdresseBroadcast(ipAddress, subnetMask);
                lblBroadcast.Text = $"Adresse de broadcast : {adresseBroadcast}";

                // Calculer et afficher la dernière adresse IP dans le mode réseau
                string derniereIPReseau = CalculerDerniereAdresseIPReseau(adresseBroadcast, cidr) ;
                lblDmachine.Text = $"Dernière IP : {derniereIPReseau}";

                // Calculer et afficher le nombre d'ips
                int nombreIP = CalculerNombreIP(cidr);
                lblnbIP.Text = $"Nombre d'adresses IP : {nombreIP}";

                // Calculer et afficher le nombre de machines
                int nombreMachine = CalculerNombreMachines(cidr);
                lblNbMachines.Text = $"Nombre de machines : {nombreMachine}";

                if (!string.IsNullOrWhiteSpace(txtboxIP.Text) && !string.IsNullOrWhiteSpace(txtboxCIDR.Text))
                {

                    lblCIDR.Text = $"CIDR : {cidr}";
                }
                else if (!string.IsNullOrWhiteSpace(txtboxIP2.Text) && !string.IsNullOrWhiteSpace(txtboxMasque.Text))
                {
                    // Récupérer le CIDR correspondant au masque
                    int cidrFromMask = CalculerCIDRDepuisMasque(subnetMask);
                    lblCIDR.Text = $"CIDR : {cidrFromMask}";
                }
            }
            else
            {
                // Afficher un message d'erreur si l'adresse IP est invalide
                lblClasse.Text = "Adresse IP invalide";
                lblAdresseIP.Text = string.Empty;
                lblMasquedesousreseau.Text = string.Empty;
            }
        }

        private string ObtenirMasque(int cidr)
        {
            // Calculer le masque en utilisant un entier 32 bits (0xFFFFFFFF)
            uint mask = 0xFFFFFFFF << (32 - cidr);

            // Convertir le masque en une chaîne binaire de 32 bits
            string binaireMasque = Convert.ToString((int)mask, 2).PadLeft(32, '0');

            // Diviser la chaîne binaire en octets (8 bits) et les stocker dans un tableau
            string[] octetsBinaires = new string[4];
            for (int i = 0; i < 4; i++)
            {
                octetsBinaires[i] = binaireMasque.Substring(i * 8, 8);
            }

            // Convertir chaque octet binaire en décimal et les concaténer avec des points
            string masque = string.Join(".", octetsBinaires.Select(octet => Convert.ToInt32(octet, 2)));

            return masque;
        }




        private string EnBinaire(string masque)
        {
            // Séparer les octets du masque
            string[] octets = masque.Split('.');

            // Déclarer une variable pour stocker la représentation binaire du masque
            string binaireMasque = "";

            // Convertir chaque octet en binaire et les concaténer avec des points
            foreach (string octet in octets)
            {
                // Convertir l'octet en entier
                int valeurOctet = int.Parse(octet);

                // Convertir l'octet en binaire et le formater avec 8 chiffres
                string binaireOctet = Convert.ToString(valeurOctet, 2).PadLeft(8, '0');

                // Ajouter l'octet binaire à la représentation du masque avec un point
                binaireMasque += binaireOctet + ".";
            }

            // Supprimer le dernier point ajouté
            binaireMasque = binaireMasque.TrimEnd('.');

            // Retourner la représentation binaire complète du masque de sous-réseau avec des points
            return binaireMasque;
        }





        private int CalculerCIDRDepuisMasque(string subnetMask)
        {
            uint mask = 0;
            string[] octets = subnetMask.Split('.');
            for (int i = 0; i < 4; i++)
            {
                mask += uint.Parse(octets[i]) << (24 - (i * 8));
            }
            int cidr = 0;
            while (mask > 0)
            {
                cidr += (int)(mask & 1);
                mask >>= 1;
            }
            return cidr;
        }

        private string CalculerAdresseBroadcast(string adresseIP, string masqueSousReseau)
        {
            string[] octetsIP = adresseIP.Split('.');
            string[] octetsMasque = masqueSousReseau.Split('.');
            string adresseBroadcast = "";

            for (int i = 0; i < 4; i++)
            {
                int octetIP = int.Parse(octetsIP[i]);
                int octetMasque = int.Parse(octetsMasque[i]);
                int octetInverseMasque = ~octetMasque & 0xFF;
                int octetBroadcast = octetIP | octetInverseMasque;
                adresseBroadcast += octetBroadcast.ToString() + ".";
            }

            adresseBroadcast = adresseBroadcast.TrimEnd('.');
            return adresseBroadcast;
        }

        private int CalculerNombreIP(int cidr)
        {
            return (int)Math.Pow(2, (32 - cidr));
        }

        private int CalculerNombreMachines(int cidr)
        {
            if (cidr >= 32)
            {
                return 0;
            }
            return (int)Math.Pow(2, (32 - cidr)) - 2;
        }




        private string CalculerAdresseReseau(string adresseIP, string masqueSousReseau)
        {
            string[] octetsIP = adresseIP.Split('.');
            string[] octetsMasque = masqueSousReseau.Split('.');
            string adresseReseau = "";

            for (int i = 0; i < 4; i++)
            {
                int octetIP = int.Parse(octetsIP[i]);
                int octetMasque = int.Parse(octetsMasque[i]);
                int octetReseau = octetIP & octetMasque;
                adresseReseau += octetReseau.ToString() + ".";
            }

            adresseReseau = adresseReseau.TrimEnd('.');
            return adresseReseau;
        }


        private void pnlB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void pnlB_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point endPoint = this.PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            }
        }

        private void pnlB_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Réinitialiser le point de départ
                startPoint = Point.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Réinitialiser les champs de texte
            txtboxMasque.Text = string.Empty;
            txtboxIP2.Text = string.Empty;
            txtboxCIDR.Text = string.Empty;
            txtboxIP.Text = string.Empty;

            // Réinitialiser les valeurs des labels
            lblClasse.Text = initialClasseText;
            lblAdresseIP.Text = initialAdresseIPText;
            lblMasquedesousreseau.Text = initialMasqueText;
            lblReseau.Text = initialReseauText;
            lblBroadcast.Text = initialBroadcastText;
            lblnbIP.Text = initialNbMachineText;
            lblIPB.Text = initialIPBText;
            lblMasqueB.Text = initialMasqueBText;
            lblPmachine.Text = initialPmachineText;
            lblDmachine.Text = initialDmachineText;

            // Réinitialiser le CIDR avec sa valeur initiale
            lblCIDR.Text = initialCIDRText;

            // Réinitialiser le nombre de machines avec sa valeur initiale
            lblNbMachines.Text = initialNbMachinesText;
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
        }

        private bool IPSpeciale(string ipAddress, out string? message)
        {
            uint ip = ConvertIPToUInt32(ipAddress);

            foreach (var range in specialIPRanges)
            {
                uint startIP = ConvertIPToUInt32(range.Start);
                uint endIP = ConvertIPToUInt32(range.End);

                if (ip >= startIP && ip <= endIP)
                {
                    message = $"L'adresse IP {ipAddress} est spéciale : {range.Description}";
                    return true;
                }
            }

            message = null;
            return false;
        }

        private uint ConvertIPToUInt32(string ipAddress)
        {
            var segments = ipAddress.Split('.').Select(byte.Parse).ToArray();
            return ((uint)segments[0] << 24) | ((uint)segments[1] << 16) | ((uint)segments[2] << 8) | segments[3];
        }


        private bool ValidationIP(string ipAddress)
        {
            string pattern = @"^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])$";



            return Regex.IsMatch(ipAddress, pattern);
        }

        private bool ValidationCIDR(string cidr)
        {
            string pattern = @"^([0-9]|[12][0-9]|3[0-2])$";
            return Regex.IsMatch(cidr, pattern);
        }


        private string CalculerPremiereAdresseIPReseau(string adresseReseau, int cidr)
        {
            // Convertir l'adresse réseau en un entier de 32 bits
            string[] octetsReseau = adresseReseau.Split('.');
            uint adresseReseauInt = 0;
            for (int i = 0; i < 4; i++)
            {
                adresseReseauInt = (adresseReseauInt << 8) + uint.Parse(octetsReseau[i]);
            }

            // Calculer la première adresse IP valide
            uint premiereAdresseIPInt = adresseReseauInt + (cidr < 31 ? 1u : 0u);

            // Convertir l'entier de 32 bits en une adresse IP
            string[] octetsPremiereAdresseIP = new string[4];
            for (int i = 3; i >= 0; i--)
            {
                octetsPremiereAdresseIP[i] = (premiereAdresseIPInt & 0xFF).ToString();
                premiereAdresseIPInt >>= 8;
            }

            // Rejoindre les octets pour former l'adresse IP
            return string.Join(".", octetsPremiereAdresseIP);
        }


        private string CalculerDerniereAdresseIPReseau(string adresseBroadcast, int cidr)
        {
            // Convertir l'adresse de broadcast en un entier de 32 bits
            string[] octetsBroadcast = adresseBroadcast.Split('.');
            uint adresseBroadcastInt = 0;
            for (int i = 0; i < 4; i++)
            {
                adresseBroadcastInt = (adresseBroadcastInt << 8) + uint.Parse(octetsBroadcast[i]);
            }

            // Calculer la dernière adresse IP valide
            uint derniereAdresseIPInt = adresseBroadcastInt - (cidr < 31 ? 1u : 0u);

            // Convertir l'entier de 32 bits en une adresse IP
            string[] octetsDerniereAdresseIP = new string[4];
            for (int i = 3; i >= 0; i--)
            {
                octetsDerniereAdresseIP[i] = (derniereAdresseIPInt & 0xFF).ToString();
                derniereAdresseIPInt >>= 8;
            }

            // Rejoindre les octets pour former l'adresse IP
            return string.Join(".", octetsDerniereAdresseIP);
        }






        private void Form1_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }
        private void ApplyRoundedCorners()
        {
           
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

    }
}