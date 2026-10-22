int gepPont = 0;
int jatekosPont = 0;
int GyozelmiPont = 3;
int merkozesSzam = 0;
char valasztottMenupont = '0';
int jatekosgyozelem = 0;
int gepgyozelem = 0;
int korokSzama = 0;
int dontetlenKorok = 0;

Random random = new Random();
do
{
    Konzol.Cim("KŐ - PAPÍR - OLLÓ");
    Konzol.Menupont("Új mérkőzés", "1");
    Konzol.Menupont("Statisztika", "2");
    Konzol.Menupont("Statisztika nullázása", "3");
    Konzol.Menupont("Kilépés", "K");
    Console.WriteLine("Választás: ");
    Console.WriteLine("");

    ConsoleKeyInfo menupont = Console.ReadKey(true);
    valasztottMenupont = char.ToLower(menupont.KeyChar);

    switch (valasztottMenupont)
    {
        case '1':
            Konzol.Siker("Új mérkőzés indítása...");
            merkozesSzam++;
            int jelenlegijatekos = 0;
            int jelenlegigep = 0;

            do
            {
                Console.WriteLine($"\nJátékos pont: {jelenlegijatekos} | Gép pont: {jelenlegigep}");
                Console.WriteLine("Válassz: Kő (K), Papír (P), Olló (O) vagy Kilépés (X): ");

                ConsoleKeyInfo jatekosValasztas = Console.ReadKey(true);
                char jatekosValasztasChar = char.ToLower(jatekosValasztas.KeyChar);

                if (jatekosValasztasChar == 'x')
                {
                    Konzol.Siker("Mérkőzés megszakítva.");
                    break;
                }

                if (jatekosValasztasChar != 'k' && jatekosValasztasChar != 'p' && jatekosValasztasChar != 'o')
                {
                    Konzol.Hiba("Érvénytelen gomb! Használd a K, P, O vagy X billentyűket.");
                    continue;
                }

                Console.WriteLine($"Játékos választása: {jatekosValasztasChar}");

                int gepValasztasSzam = random.Next(1, 4);
                char gepValasztasChar = gepValasztasSzam switch
                {
                    1 => 'k',
                    2 => 'p',
                    _ => 'o'
                };
                korokSzama++;
                Console.WriteLine($"Gép választása: {gepValasztasChar}");

                if ((jatekosValasztasChar == 'k' && gepValasztasChar == 'o') ||
                    (jatekosValasztasChar == 'p' && gepValasztasChar == 'k') ||
                    (jatekosValasztasChar == 'o' && gepValasztasChar == 'p'))
                {
                    Konzol.Siker("Játékos nyerte a kört!");
                    Console.WriteLine("");
                    jelenlegijatekos++;
                    jatekosPont++;
                }
                else if ((gepValasztasChar == 'k' && jatekosValasztasChar == 'o') ||
                         (gepValasztasChar == 'p' && jatekosValasztasChar == 'k') ||
                         (gepValasztasChar == 'o' && jatekosValasztasChar == 'p'))
                {
                    Konzol.Hiba("Gép nyerte a kört!");
                    Console.WriteLine("");
                    jelenlegigep++;
                    gepPont++;
                }
                else
                {
                    Konzol.Hiba("Döntetlen!");
                    Console.WriteLine("");
                    dontetlenKorok++;
                }
            } while (jelenlegijatekos < GyozelmiPont && jelenlegigep < GyozelmiPont);

            
            if (jelenlegijatekos >= GyozelmiPont)
            {
                Konzol.Siker("A játékos nyerte a mérkőzést!");
                Console.WriteLine("");
                jatekosgyozelem++;
            }
            else if (jelenlegigep >= GyozelmiPont)
            {
                Konzol.Hiba("A gép nyerte a mérkőzést!");
                Console.WriteLine("");
                gepgyozelem++;
            }
            break;

        case '2':
            Konzol.Siker("Statisztika megtekintése...");
            Console.WriteLine("--- Statisztika ---");

            double gyozelmiArany = merkozesSzam == 0
                ? 0
                : (double)jatekosgyozelem / merkozesSzam * 100;

            Console.WriteLine($"Mérkőzések: {merkozesSzam} (nyert: {jatekosgyozelem}, vesztett: {gepgyozelem})");
            Console.WriteLine($"Győzelmi arány: {gyozelmiArany:0.##}%");
            Console.WriteLine($"Körök: {korokSzama} (nyert: {jatekosPont}, vesztett: {gepPont}, döntetlen: {dontetlenKorok})");
            Console.WriteLine("");
            break;
        case '3':
            Console.WriteLine("Biztos akarod nullázni? (i/n) ");
            string valasz = Console.ReadLine();
            if (valasz == "i")
            {
                Konzol.Siker("Statisztika nullázása...");
                gepPont = 0;
                jatekosPont = 0;
                merkozesSzam = 0;
                jatekosgyozelem = 0;
                gepgyozelem = 0;
                korokSzama = 0;
                dontetlenKorok = 0;
                Console.WriteLine("");
            }
            else if (valasz == "n")
            {
                Console.WriteLine("Nem nulláztuk!");
                Console.WriteLine("");
            }
            else
            {
                Konzol.Hiba("Érvénytelen választás! Statisztika nem nullázva.");
                Console.WriteLine("");
            }
            break;

        case 'k':
            Konzol.Siker("Kilépés a programból...");
            break;

        default:
            Konzol.Hiba("Érvénytelen választás!");
            Console.WriteLine("");
            break;
    }

} while (valasztottMenupont != 'k');