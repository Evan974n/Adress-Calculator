using Microsoft.VisualBasic.ApplicationServices;
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
        private Point startPoint;

        private readonly Dictionary<string, string> specialIPRanges = new Dictionary<string, string>
{
    { "0.0.0.0", "\"This\" Network RFC 1122, Section 3.2.1.3" },
    { "10.0.0.0", "Private-Use Networks RFC 1918" },
    { "127.0.0.0", "Loopback RFC 1122, Section 3.2.1.3" },
    { "169.254.0.0", "Link Local RFC 3927" },
    { "172.16.0.0", "Private-Use Networks RFC 1918" },
    { "192.0.0.0", "IETF Protocol Assignments RFC 5736" },
    { "192.0.2.0", "TEST-NET-1 RFC 5737" },
    { "192.88.99.0", "6to4 Relay Anycast RFC 3068" },
    { "192.168.0.0", "Private-Use Networks RFC 1918" },
    { "198.18.0.0", "Network Interconnect Device Benchmark Testing RFC 2544" },
    { "198.51.100.0", "TEST-NET-2 RFC 5737" },
    { "203.0.113.0", "TEST-NET-3 RFC 5737" },
    { "224.0.0.0", "Multicast RFC 3171" },
    { "240.0.0.0", "Reserved for Future Use RFC 1112, Section 4" },
    { "255.255.255.255", "Limited Broadcast RFC 919, Section 7; RFC 922, Section 7" }
};
        public Form1()
        {
            InitializeComponent();

            // Stockez les valeurs initiales des labels
            initialClasseText = lblClasse.Text;
            initialAdresseIPText = lblAdresseIP.Text;
            initialMasqueText = lblMasquedesousreseau.Text;
            initialReseauText = lblReseau.Text;
            initialBroadcastText = lblBroadcast.Text;
            initialNbMachineText = lblnbMachine.Text;
            initialIPBText = lblIPB.Text;
            initialMasqueBText = lblMasqueB.Text;
            initialPmachineText = lblPmachine.Text;
            initialDmachineText = lblDmachine.Text;
        }

        private void Btnretour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void btbnCalculer_Click(object sender, EventArgs e)
        {

            // Lire les entrées des TextBox
            string masqueInput = txtboxMasque.Text;
            string ip2Input = txtboxIP2.Text;
            string cidrInput = txtboxCIDR.Text;
            string ipInput = txtboxIP.Text;

            // Vérifier si les champs IP et CIDR sont remplis
            bool isIPAndCIDRProvided = !string.IsNullOrWhiteSpace(ipInput) && !string.IsNullOrWhiteSpace(cidrInput);

            // Vérifier si les champs IP2 et Masque sont remplis
            bool isIP2AndMasqueProvided = !string.IsNullOrWhiteSpace(ip2Input) && !string.IsNullOrWhiteSpace(masqueInput);

            if (isIPAndCIDRProvided && isIP2AndMasqueProvided)
            {
                MessageBox.Show("Veuillez remplir soit les champs IP et CIDR, soit les champs IP2 et Masque, mais pas les deux ensembles.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sortir de la méthode si les deux ensembles de champs sont remplis
            }
            else if (isIPAndCIDRProvided)
            {
                // Valider IP et CIDR
                if (!ValidationIP(ipInput))
                {
                    MessageBox.Show("Le format de l'adresse IP est invalide. Veuillez entrer une adresse IP valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sortir de la méthode si l'adresse IP est invalide
                }
                else if (!ValidationCIDR(cidrInput))
                {
                    MessageBox.Show("Le format du CIDR est invalide. Veuillez entrer un CIDR valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sortir de la méthode si le CIDR est invalide
                }

                // Vérifier si l'adresse IP appartient à une plage spéciale
                if (IPSpeciale(ipInput, out string? specialMessage))
                {
                    MessageBox.Show(specialMessage, "Adresse IP spéciale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Si validation réussie, calculer et afficher la classe IP et le masque de sous-réseau
                AfficherClasseIPetMasque(ipInput, int.Parse(cidrInput));
            }
            else if (isIP2AndMasqueProvided)
            {
                // Valider IP2 et Masque
                if (!ValidationIP(ip2Input))
                {
                    MessageBox.Show("Le format de l'adresse IP secondaire est invalide. Veuillez entrer une adresse IP valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sortir de la méthode si l'adresse IP secondaire est invalide
                }
                else if (!ValidationIP(masqueInput))
                {
                    MessageBox.Show("Le format de l'adresse IP du masque est invalide. Veuillez entrer une adresse IP valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sortir de la méthode si l'adresse IP du masque est invalide
                }

                // Si validation réussie, calculer et afficher la classe IP pour ip2Input
                AfficherClasseIPetMasque(ip2Input, CalculerCIDRDepuisMasque(masqueInput));
            }
            else
            {
                MessageBox.Show("Veuillez remplir soit les champs IP et CIDR, soit les champs IP2 et Masque.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sortir de la méthode si aucun ensemble de champs n'est rempli
            }
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
                string premiereIPReseau = CalculerPremiereAdresseIPReseau(adresseReseau);
                lblPmachine.Text = $"Première IP : {premiereIPReseau}";

                // Calculer et afficher l'adresse de broadcast
                string adresseBroadcast = CalculerAdresseBroadcast(ipAddress, subnetMask);
                lblBroadcast.Text = $"Adresse de broadcast : {adresseBroadcast}";

                // Calculer et afficher la dernière adresse IP dans le mode réseau
                string derniereIPReseau = CalculerDerniereAdresseIPReseau(adresseBroadcast);
                lblDmachine.Text = $"Dernière IP : {derniereIPReseau}";

                // Calculer et afficher le nombre de machines
                int nombreMachines = CalculerNombreMachines(cidr);
                lblnbMachine.Text = $"Nombre de machines : {nombreMachines}";
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
            uint mask = 0xFFFFFFFF << (32 - cidr);
            return $"{(mask >> 24) & 0xFF}.{(mask >> 16) & 0xFF}.{(mask >> 8) & 0xFF}.{mask & 0xFF}";
        }

        private string EnBinaire(string adresseIP)
        {
            string[] octets = adresseIP.Split('.');
            string binaireIP = "";

            foreach (string octet in octets)
            {
                string octetBinaire = Convert.ToString(int.Parse(octet), 2).PadLeft(8, '0');
                binaireIP += octetBinaire + ".";
            }

            // Supprimer le dernier point ajouté
            binaireIP = binaireIP.TrimEnd('.');

            return binaireIP;
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

        private int CalculerNombreMachines(int cidr)
        {
            return (int)Math.Pow(2, (32 - cidr)) -2;
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

            // Restaurer les valeurs initiales des labels
            lblClasse.Text = initialClasseText;
            lblAdresseIP.Text = initialAdresseIPText;
            lblMasquedesousreseau.Text = initialMasqueText;
            lblReseau.Text = initialReseauText;
            lblBroadcast.Text = initialBroadcastText;
            lblnbMachine.Text = initialNbMachineText;
            lblIPB.Text = initialIPBText;
            lblMasqueB.Text = initialMasqueBText;
            lblPmachine.Text = initialPmachineText;
            lblDmachine.Text = initialDmachineText;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool IPSpeciale(string ipAddress, out string? message)
        {
            if (specialIPRanges.TryGetValue(ipAddress, out string? specialMessage))
            {
                message = $"L'adresse IP {ipAddress} est spéciale : {specialMessage}";
                return true;
            }
            message = null;
            return false;
        }

        private bool ValidationIP(string ipAddress)
        {
            string pattern = @"^(25[0-5]|2[0-4][0-9]|[1-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[1-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[1-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[1-9][0-9]?)$";


            return Regex.IsMatch(ipAddress, pattern);
        }

        private bool ValidationCIDR(string cidr)
        {
            string pattern = @"^([0-9]|[12][0-9]|3[0-2])$";
            return Regex.IsMatch(cidr, pattern);
        }

        private void lblClasse_Click(object sender, EventArgs e)
        {

        }

        private string CalculerPremiereAdresseIPReseau(string adresseReseau)
        {
            // Séparer les octets de l'adresse réseau
            string[] octetsReseau = adresseReseau.Split('.');

            // Modifier le dernier octet pour obtenir la première adresse IP disponible
            octetsReseau[3] = (int.Parse(octetsReseau[3]) + 1).ToString();

            // Rejoindre les octets pour former l'adresse IP
            return string.Join(".", octetsReseau);
        }

        private string CalculerDerniereAdresseIPReseau(string adresseBroadcast)
        {
            // Séparer les octets de l'adresse de broadcast
            string[] octetsBroadcast = adresseBroadcast.Split('.');

            // Modifier le dernier octet pour obtenir la dernière adresse IP disponible
            octetsBroadcast[3] = (int.Parse(octetsBroadcast[3]) - 1).ToString();

            // Rejoindre les octets pour former l'adresse IP
            return string.Join(".", octetsBroadcast);
        }



    }
}