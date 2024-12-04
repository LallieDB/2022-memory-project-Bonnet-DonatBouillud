bool VerifieSynthaxe(string reponse, int a, int b)
{
    //Cette fonction vérifie si la réponse entrée par le joueur est valide.
    //-elle retourne true si la reponse est valide
    //-sinon, elle retourne false
    //
    //Si l'on veut juste vérifier que la réponse est bien un (int):
    // - a=0 et b=0
    //--> la fonction vérifie si la réponse est bien un (int)
    //
    //Si l'on veut vérifier que la réponse est bien dans un intervalle [|a,b|]:
    // - a!=0 et b!=0
    //--> la fonction vérifie d'abord si la réponse est bien un (int)
    //--> elle vérifie ensuite si cette réponse est bien dans l'intervalle [|a,b|]
    //
    // reponse (stinrg) est la réponse entrée par l'utilisateur 
    // a (int) et b (int) sont les entiers de l'intervalle de restriction de valeurs [|a,b|]

    bool sol=false;
    int reponseInt;
    //Création de l'intervalle
    int[] valeurAutorise=new int[b-a+1];
    for (int k=0;k<b-a+1;k++)
    {
        valeurAutorise[k]=a+k;
    }

    //On vérifie si reponse est bien un (int)
    if (int.TryParse(reponse, out reponseInt)==false)
    {
        Console.WriteLine ("\nErreur :\nVotre réponse n'est pas valide, vous devez tapez un nombre.\n");
    }

    //Si il n'y a pas d'intervalle de restriction de valeur, alors la réponse est autorisée
    else if (a==0 && b==0)
    {
        sol=true;
    }

    //Si l'intervalle est restreint, on vérifie que reponse est inclu dans l'intervalle
    else
    {
        reponseInt=Convert.ToInt32 (reponse);
        for (int k=0; k<valeurAutorise.Length ;k++)
        {
            if (valeurAutorise[k]==reponseInt)
            {
                sol=true;
                break;
            }
        }
        if (sol==false)
        {
            Console.WriteLine ("\nErreur :\nVotre réponse n'est pas valide, vous devez tapez un des chiffre parmis ceux proposés.\n");
        }
    }
    return sol;
}

int choixModeDeJeu()
{
    //Cette fonction demande au(x) joueur(s) le mode de jeu qu'il(s) souhaite(nt)
    //-elle retourne 1 (int) pour le "Mode Solo"
    //-elle retourne 2 (int) pour le "Mode MultiJoueurs"
    //-elle retourne 3 (int) pour "Joueur avec une IA"

    string reponse = " ";
    bool sol=false;

    Console.WriteLine ("************** M E M O R Y **************");

    Console.WriteLine ("\nBonjour et bienvenue au jeu de Memory");
    do
    {
        Console.WriteLine ("Choisissez votre mode de jeu :\n");
        Console.WriteLine (" ---------------     ----------------------     -----------------------");
        Console.WriteLine ("| Mode Solo = 1 |   | Mode MultiJoueurs = 2 |   | Jouer avec une IA = 3 |");
        Console.WriteLine (" ---------------     ----------------------     -----------------------");
        Console.Write ("\nVotre réponse : ");

        reponse = Console.ReadLine()!;
        //On vérifie si la réponse est valide
        sol=VerifieSynthaxe(reponse,1,3);
    }
    while (sol==false);

    return Convert.ToInt32 (reponse);
}

string[] DetermineNbJoueurs(int choixMode)
{
    //Cette fonction va permettre de déterminer le nombre du joueur en fonction du mode choisit choixMode (int)
    //Elle demande donc le nombre de joueur si le mode choisit est celui est le ModeMultijoueurs
    //Sinon, elle créer d'elle même le bon nombre de joueurs
    //Elle rtourne nomJoueur (string[]) de la taille du nombre de joueur. Ce tableau stockera ensuite le(s) nom(s) du(des) joueur(s)

    string reponse;
    int reponseInt=0;
    bool sol=false;

    if (choixMode==1)
    {
        Console.WriteLine (" -----------");
        Console.WriteLine ("| Mode Solo |");
        Console.WriteLine (" -----------");
        string[] nomJoueur=new string[1];
        return nomJoueur;
    }

    else if (choixMode ==2)
    {
        Console.WriteLine (" ------------------- ");
        Console.WriteLine ("| Mode MultiJoueurs |");
        Console.WriteLine (" -------------------");
        while (sol==false)
        {
            Console.WriteLine ("\nCombien de joueurs ? (Il y a une limite de 10 joueurs)");
            Console.WriteLine ("Votre réponse : ");
            reponse=Console.ReadLine ()!;
            sol=VerifieSynthaxe(reponse,1,10);

            if (sol ==true)
            {
                reponseInt=Convert.ToInt32(reponse);
                if (reponseInt<2)
                {
                    Console.WriteLine ("Vous devez chosir un nombre strictement supérieur à 1.");
                    sol=false;
                }
            }
        }
        string[] nomJoueur=new string[reponseInt];
        return nomJoueur ;
    }
    else //(choixMode ==3)
    {
        Console.WriteLine (" -------------------");
        Console.WriteLine ("| Jouer avec une IA |");
        Console.WriteLine (" -------------------");
        string[] nomJoueur=new string[2];
        return nomJoueur;
    }
}

int NombreCoupsLimite(int nbCartesParUplet)
{
    // Cette fonction demande au joueur s'il souhaite jouer avec un nombre de tour limité.
    // Si non, la fonction retourne 0;
    // Si oui, le joueur doit entrer le nombre de tour qu'il souhaite, la fonction retourne alors ce nombre.
    
    // nbCartesParUplet (int) est le nombre de cartes identique dans le jeu.

    int k=0; // k va nous permettre de savoir à quelle page nous sommes
    string reponse0=" "; // réponse du joueur
    int reponseInt=0;
    int choix=0;
    bool sol;

    while (k!=2) //Tant que nous ne sommes pas à la page finale
    {
        if (k==0)
        {
            sol=false;

            while (sol==false)
            {
                Console.WriteLine ("Voulez vous jouez avec un nombre de tour limité ?");
                Console.WriteLine ("\n----------------------------------------");
                Console.WriteLine ("     ---------             ---------");
                Console.WriteLine ("    | Oui = 1 |           | Non = 2 |");
                Console.WriteLine ("     ---------             ---------");
                Console.WriteLine ("----------------------------------------\n");
                Console.Write ("Ecrivez la réponse : ");

                reponse0=(Console.ReadLine ()!);
                //On vérifie si la réponse est valide
                sol=VerifieSynthaxe(reponse0,1,2);
                if (sol==true)
                {
                    reponseInt=Convert.ToInt32(reponse0);
                }
                k=1;
            }

        }
        if (k==1)
        {
            if (reponseInt ==2) // "non"
            {
                choix=0;
                break;
            }
                
            else // "oui"
            {   sol=false;

                while (sol==false)
                {
                    Console.WriteLine ("\n----------------------------------------\n");
                    Console.WriteLine ($"Vous pouvez jouer avec au minimun {nbCartesParUplet} tours.");
                    Console.WriteLine ("Avec combien de tours voulez vous jouer ? ");
                    Console.WriteLine ("\n-------------------------------------------------------");
                    Console.WriteLine ("     --------------------             ------------");
                    Console.WriteLine ("    | Nombre de tour = ? |           | Retour = 0 |");
                    Console.WriteLine ("     --------------------             ------------");
                    Console.WriteLine ("-------------------------------------------------------\n");
                    Console.Write ("Ecrivez la réponse : ");

                    reponse0=(Console.ReadLine ()!);
                    //On vérifie si la réponse est valide
                    sol=VerifieSynthaxe(reponse0,0,0);

                    if (sol==true)
                    {
                        reponseInt=Convert.ToInt32(reponse0);

                        if (reponseInt==0)
                            break;

                        if (reponseInt<nbCartesParUplet)
                        {
                            Console.WriteLine ("\nErreur :\nVous devez choisir un nombre de tours plus élevé.");
                            sol=false;
                        }
                    }
                }
            }

            if (reponseInt==0)
                k=0;
            else
            {
                choix=reponseInt;
                k=2;
            }
        }
    }
    return choix;
}

string[] demandeNomJoueur(int choixMode,string[] nomJoueur)
{
    //Cette fonction demande au(x) joueur(s) son(leur) nom(s) les placent dans nomJoueur (string[])
    //Elle retourne nomJoueur modifié.
    
    string reponse;
    int reponseInt=0;
    bool sol=false;

    if (choixMode ==1)
    {
        Console.WriteLine ("\nEntrez votre nom d'utilisateur.");
        Console.Write("Votre réponse :");
        nomJoueur[0]=Console.ReadLine ()!;
        return nomJoueur;
    }
    else if (choixMode ==2)
    {
        for (int k=0;k<nomJoueur.Length ;k++)
        {
            Console.Write($"\nEntrez le nom du joueur {k+1} : ");
            nomJoueur[k]=Console.ReadLine ()!;
        }
        return nomJoueur;
    }
    else // (choixMode ==3)
    {
        Console.WriteLine ("\nEntrez votre nom d'utilisateur.");
        Console.Write("Votre réponse :");
        nomJoueur[0]=Console.ReadLine ()!;
        while (sol==false)
        {
            Console.WriteLine ("\nChoisissez le niveau de l'IA avec laquelle vous allez jouer");
            Console.WriteLine (" ---------");
            Console.WriteLine ("| Niveau 1|");
            Console.WriteLine (" ---------");
            Console.Write ("\nVotre réponse :");
            reponse = Console.ReadLine ()!;
            sol=VerifieSynthaxe(reponse,1,1);

            if (sol==true)
            {
                reponseInt=Convert.ToInt32(reponse);
                Console.WriteLine ($"Vous avez choisi le Niveau {reponseInt}");
                if (reponseInt ==1)
                {
                    Console.WriteLine ("  < >____< >      _");
                    Console.WriteLine (" | o     o  |   _| |");
                    Console.WriteLine (" | -- ^ --  |  | __|");
                    Console.WriteLine (" |          |  | |");
                    Console.WriteLine ("Vous allez jouer contre Patate");
                    nomJoueur[1]="Patate";
                }
            }
        }
        return nomJoueur;
    }
}

int DemanderCartesIndent()
{
    //Demande au joueur le nombre de cartes identiques formant les n-uplets
    //Ne prend rien en entrée
    //retourne nbCartesParUplet (int)

    bool sol=false;
    string reponse;
    int nbCartesParUplet=0;

    while (sol==false)
    {
        Console.WriteLine("Choisissez le nombre de nuplets différents avec lequels vous souhaitez jouez :");
        Console.Write("\nVotre réponse : ");

        reponse = Console.ReadLine()!;
        sol = VerifieSynthaxe (reponse ,0,0);

        if (sol==true)
        {
            nbCartesParUplet=Convert.ToInt32(reponse);
            if (nbCartesParUplet <=1)
            {
                Console.WriteLine ("Vous devez choisir un nombre plus grand.");
                sol=false;
            }
        }
    }

    return nbCartesParUplet;
}

int [] RetournePosetMax(int[] joueur)
{
    // Cette fonction retourne la position du max et le nombre maximal d'un tableau
    // Le tableau de retour renvoie d'abord la position puis le maximum
    int[] posEtMax= new int[2];
    posEtMax[0]=0;
    posEtMax[1]=joueur[0];
    for (int i=1; i<joueur.Length;i++)
    {
        if(joueur[i]>posEtMax[1])
        {
            posEtMax[1]=joueur[i];
            posEtMax[0]=i;
        }
    }
    return posEtMax;
}

int DemanderNbUplet()
{
    // Demande au joueur le nombre de n-uplet qu'il souhaite rechercher
    // Aucun argument d'entré
    // Retourne nbUplet (int)

    bool sol=false;
    string reponse;
    int nbUplet=0;

    while (sol==false)
    {
        Console.WriteLine("Combien de n-uplet souhaitez vous avoir à rechercher? ");
        Console.WriteLine("Pour jouer avec des paires, tapez 2. Pour jouer avec des groupes de trois, tapez 3 ...");
        Console.Write("\nVotre réponse : ");

        reponse = Console.ReadLine()!;
        sol = VerifieSynthaxe (reponse ,0,0);
        if (sol==true)
        {
            nbUplet = int.Parse(reponse);
            if (nbUplet <=0)
            {
                Console.WriteLine ("Vous devez choisir un nombre plus grand.");
                sol=false;
            }
        }
    }
    return nbUplet;
}

int [] Egalite (int[] joueur)
{
    // Cette fonction renvoie les joueurs ayant un score égal.
    // Si il n'y a pas d'égalité, elle renvoie un tableau de 0
    // Elle prend arbitrairement le cas maximal de 10 joueurs ayant obtenus le même score
    int[] joueurEgaux = new int[10];
    for (int k=0; k<joueur.Length;k++)
    {
        joueurEgaux[k]=0;
    }
    int max= joueur[0];
    for (int i=0;i<joueur.Length-1;i++)
    {
        if (joueur[i]>=max)
        {
            if (joueur[i]>max)
            {
                for (int k=0; k<joueur.Length;k++)
                {
                    joueurEgaux[k]=0;
                }
            }
            max=joueur[i];
            for (int j=i+1;j<joueur.Length;j++)
                if (joueur[i]==joueur[j])
                {
                    joueurEgaux[i]=1;
                    joueurEgaux[j]=1;
                }
        }
        
    }
    if (joueur[joueur.Length-1]>max)
    {
      for (int k=0; k<joueur.Length;k++)
        {
            joueurEgaux[k]=0;
        }  
    }
    return joueurEgaux;
}

int[] OptimisationPlateau(int nbCartesParUplet, int nbUplets)
{
    // Le but de cette fonction est d'optimiser la taille du plateau de jeu
    // Pour ce faire, on va chercher les diviseurs de n=nbCartesParUplet * nbUplets
    // Au fur et à mesure des boucles, longueur va augmenter tant que largeur va diminuer
    // Il arrivera un moment ou longueur prendra des valeurs déjà prise par largeur et inversement
    // --> si n est un carré, alors la boucle s'arretera lorsque longueur=largeur, le plateau de jeu sera donc carré
    // --> si n n'est pas carré, alors la boucle s'arretera des que largeur prendra une valeur déjà prise par longueur,
    // autrement dit, lorsque largeur2==longueur1
    // le plateau de jeu est alors un rectangle optimisé dont la longueur est légèrement supérieur à la largeur.
    // Nous avons choisi de prendre une taille de plateau dont la longueur>largeur mais l'autre cas est aussi possible,
    // il suffit dans ce cas de retourner {longueur1,largeur1}
    //
    // nbCartesParUplet (int) est le nombre de cartes identiques choisi précédement par le joueur
    // nbUplets (int) est le nombre carte sur le plateau choisi précédement par le joueur 

    int n=nbCartesParUplet * nbUplets;
    int longueur1=0;
    int largueur1=0;
    int longueur2=1;
    int largeur2=n;
    while (longueur1!=largeur2 && longueur2!=largeur2)
    {
        longueur1=longueur2;
        largueur1=largeur2;
        longueur2+=1;
        while (n%longueur2!=0)
        {
            longueur2+=1;
        }
        largeur2=n/longueur2;
    }
    int[] taille=new int[] {longueur2,largeur2};
    return taille;
}

bool PaireRetourne(char [,] tableauTemporaire, char[,] tableauJoueur, int[] joueur, string nomJoueur, int i, bool fin, char[,] plateauSol)
{
    // Dans le cas ou un n-uplet est retourné, on prend en argument:
    // le tableau temporaire et celui du joueur pour mettre à jour celui de joueur avec les n-uplets découvert
    // Le tableau des joueurs et le numéro du joueur (le premier est nul et le second égal à -1 si on est dans le mode solo)
    // Le booléen fin et le tableau solution pour savoir si le n-uplet retourné est le dernier
    for (int a=0; a<tableauTemporaire.GetLength(0);a++)
    {
        for (int k=0; k<tableauTemporaire.GetLength(1);k++)
        {
            tableauJoueur[a,k]=tableauTemporaire[a,k];                         
        }
    }
    if (i!=-1)
    {
        joueur[i]++;
        Console.WriteLine($"{nomJoueur} a retourné un n-uplet.");
        Console.WriteLine($"{nomJoueur} a un score de {joueur[i]}.");
        Console.WriteLine("Pressez n'importe quel bouton pour continuer.");
        Console.ReadLine();
    }
    
     // On vérifie que le tableau solution n'est pas égal au tableau du joueur
    fin=true;
    for (int a=0; a<tableauTemporaire.GetLength(0);a++)
    {
                            
        for (int k=0; k<tableauTemporaire.GetLength(1);k++)
        {
            if (tableauJoueur[a,k]!=plateauSol[a,k])
            {
                fin=false;
            }
                
        }
    }
    return fin;
}

char[,] CreerTableauInitial(int nbCartesParUplet, int nbuplet)
{
    // On initialise le tableau vide du joueur avec des *
    // On commence par optimiser la taille du tableau grâce à la fonction d'optimisation
    // On renvoye le tableau vide

    int[] dimension = OptimisationPlateau(nbCartesParUplet,nbuplet);
    char[,] tableauJoueur = new char[dimension[1],dimension[0]];
    for (int i=0;i< tableauJoueur.GetLength(0);i++)
    {
        for (int j=0;j<tableauJoueur.GetLength(1);j++)
        {
            tableauJoueur[i,j]='*';
        }
    }
    return tableauJoueur;
}

void AfficherTableau(char[,] tableau)
{
    // On créer une fonction pour afficher un tableau mis en argument d'entrée
    // On met sur les côtés les numéros des lignes et des colonnes pour que le joueur s'y retrouve mieux

    Console.Write("    ");
    for (int j=0; j<tableau.GetLength(1);j++) //On affiche les numéros de colonne au dessus de la grille
    {
        Console.Write($" {j}");
    }
    Console.WriteLine("");
    Console.Write("    ");
    for (int j=0; j<tableau.GetLength(1);j++) 
    {
        Console.Write($"- ");
    }
    Console.WriteLine("-");
    
    for (int i=0;i< tableau.GetLength(0);i++) //On affiche les caractères de la grille
    {
        Console.Write($"{i} | ");
        for (int j=0;j<tableau.GetLength(1);j++)
        {
            Console.Write($" {tableau[i,j]}");
        }
        Console.WriteLine($" | {i}");
    }
    Console.Write("    ");
    for (int j=0; j<tableau.GetLength(1);j++) //On affiche les numéros des colonnes en bas de la grille
    {
        Console.Write($"- ");
    }
    Console.WriteLine("-");
    Console.Write("    ");
    for (int j=0; j<tableau.GetLength(1);j++)
    {
        Console.Write($" {j}");
    }
    Console.WriteLine("");
}

char[,] NewPlateauSolution(int nbCartesParUplet, int nbUplets)
{
    // Le but de cette fonction est de créer le plateau de solution pour une partie de Mémory.
    // Elle va utiliser OptimisationPlateau afin d'obtenir une taille obtimal pour notre plateau.

    // nbCartesParUplet (int) est le nombre de cartes identiques choisi précédement par le joueur
    // nbUplets (int) est le nombre carte sur le plateau choisi précédement par le joueur 

    int colonne = OptimisationPlateau (nbCartesParUplet , nbUplets )[0];
    int ligne = OptimisationPlateau (nbCartesParUplet , nbUplets )[1];
    char[,] plateauSol=new char[ligne,colonne]; 

    // Création d'un tableau "cartes" contenant toutes les cartes qui seront jouées pour cette partie 
    char[] cartes=new char[nbCartesParUplet *nbUplets ]; 

    int k=0;
    while (k < cartes.Length)
    {
        Random rng1 = new Random ();
        Random rng2 = new Random ();
        int numListe=rng1.Next (1,4);
        char positionListe=' ';

        if (numListe ==1)
            positionListe = (char)rng2.Next ('A','Z');

        else if (numListe ==2)
            positionListe = (char)rng2.Next ('a','z');

        else
            positionListe = (char)rng2.Next ('0','9');

        for (int n=0;n<nbUplets ;n++)
        {
            cartes[k+n]=positionListe;
        }

        k+=nbUplets ;   
    }

    //On place ensuite aléatoirement les cartes du jeu de cette partie (rangées dans le tableau "cartes") dans le tableauSol
    Random rng3 = new Random ();
    int positionCarte=0;
    for (int i=0;i<plateauSol.GetLength (0);i++)
        for (int j=0;j<plateauSol .GetLength (1);j++)
        {
            do 
            {
            positionCarte =rng3.Next (0,cartes.Length );
            }
            while (cartes[positionCarte]==' ');

            plateauSol [i,j]=cartes[positionCarte ];
            cartes[positionCarte ]=' ';

        }

    return plateauSol ;
}

char[,] RetourneCarte (int[] position, char[,] tab, char[,] solution)
{
    // Retourne la carte choisi par le joueur sur le plateau de solution
        tab[position[0],position[1]]=solution[position[0],position[1]];
        return tab;   
}

int[] DemandePositionCartes(char[,] tableauJoueur)
{
    int[] position= new int[2];
    bool tousRetourne= false; //devrait pas être false au début ?
    int i=0;
    string reponse;
    bool sol=false;


    do 
    {
        do
        {
            i=0;
            Console.WriteLine("Dans quelle ligne se situe la carte que vous voulez retournez?");
            Console.Write("\nVotre réponse : ");

            reponse = Console.ReadLine()!;
            sol = VerifieSynthaxe (reponse,0,0);
            
            if (sol==true)
            {
                position[0]=Convert.ToInt32 (reponse);

                if (position[0]>tableauJoueur.GetLength(0)-1 || position[0]<0)
                {
                    Console.WriteLine($"Le tableau ne dispose pas de ligne {position[0]}");
                    sol=false;
                }

                // Si l'indice est dans le rang, on regarde si toutes les cartes de la ligne ne sont pas déjà retournée
                else if (position[0]<=tableauJoueur.GetLength(0)-1)
                {
                    tousRetourne= true;
                    while(i<tableauJoueur.GetLength(1)&&tousRetourne==true)
                    {
                        if (tableauJoueur[position[0],i]== '*')
                            tousRetourne=false;
                        i++;
                    }
                    if (tousRetourne==true)
                    {
                        Console.WriteLine("Les cartes sont toutes retournées dans cette ligne.");
                        sol=false;
                    }
                } 
            }
           
        }
        while(sol==false);
        do
        {
            Console.WriteLine("Dans quelle colonne se situe la carte que vous voulez retournez?");
            Console.Write("\nVotre réponse : ");

            reponse = Console.ReadLine()!;
            sol = VerifieSynthaxe (reponse,0,0);
            
            if (sol==true)
            {
                position[1]=Convert.ToInt32 (reponse);

                if (position[1]>tableauJoueur.GetLength(1)-1 || position[1]<0)
                {
                    Console.WriteLine($"Le tableau ne dispose pas de colonne {position[1]}");
                    sol=false;
                }

            }

        }
        while(sol==false);

        if (tableauJoueur[position[0],position[1]]!='*')
        {
            Console.WriteLine("Erreur : la carte que vous avez choisi est déjà retournée.");
            sol=false;
        }
    }
    
    while (sol==false);
    
    return position;

}

int[] CartesPatates(char[,] tableauJoueur)
{
    // Patate choisit les cartes de manière aléatoire
    int[] position= new int[2];
    bool tousRetourne= false; //devrait pas être false au début ?
    int i=0;
    Random rng = new Random();
    bool sol=true;
    do
    {
        sol=true;
        // On choisit aléatoirement la position de la ligne
        position[0]=rng.Next(0,tableauJoueur.GetLength(0));
        // On vérifie que dans cette ligne, toutes les cartes ne sont pas déjà retournées
        // Si elles le sont toutes, on rechoisit aléatoirement une ligne
        tousRetourne= true;
        i=0;
        while(i<tableauJoueur.GetLength(1) && tousRetourne==true)
        {
            if (tableauJoueur[position[0],i]== '*')
                tousRetourne=false;
            i++;
        }
        if (tousRetourne==true)
        {
            sol=false;
        }
    } 
    while(sol==false);
    do
    {
        sol=true;
        // On choisit aléatoirement la colonne
        position[1]=rng.Next(0,tableauJoueur.GetLength(1));
        // On vérifie que la position choisit ne correspond pas à une carte déjà retournée
        // Si c'est le cas, on choisit une aléatoirement une nouvelle colonne
        if (tableauJoueur[position[0],position[1]] !='*')
        {
            sol=false;
        }
    }
    while(sol==false);
    
    return position;

}

void Felicitations(string nomJoueur)
{
    // Renvoie un message de féliciations
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine($" FELICITATIONS {nomJoueur} !!!!");
    Console.WriteLine("               * * * * *");
    Console.WriteLine("              _|_|_|_|_|_    ");
    Console.WriteLine("             |~~~~~~~~~~|    ");
    Console.WriteLine("             |~~~~~~~~~~|     ");
    Console.WriteLine("             -----------  ");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("----------------------------------------");
}

bool VerifieCartes(int rgCarte, char[] choixTour)
{
    // choixTour est une char de dim = nbUplet
    if (rgCarte==0 || rgCarte==1)
        return true ;
    else
    {
        if(choixTour[rgCarte-2]==choixTour[rgCarte-1])
            return true ;
        else
            return false ;
    }
}

void DeterminationGagnantEtMessage(int[] joueur, string[] nomJoueurs)
{
    // Cette fonction regarde si il y a des joueurs à égalité ou un seul gagant
    // Puis elle envoye un message de félicitation au(x) gagnant(s)
    // Elle sert uniquement au mode multijoueur
    // Si il y a égalité entre plusieurs joueurs, égalité renvoye true
    bool egalite=false;
    int[] casEgalite=Egalite(joueur);
    for (int l=0;l<casEgalite.Length-1;l++)
    {
        if (casEgalite[l]==1)
            egalite=true;
    }
    // On regarde si il y a eu égalité
    if (egalite==false)
    {
        // Si il y a un gagnant on donne son score
        int[] infosGagnant = new int[2];
        infosGagnant= RetournePosetMax(joueur);
        Console.WriteLine ($"Le jeu est fini . Le gagnant est le joueur {infosGagnant[0]+1}. Il a marqué {infosGagnant[1]} points.");
        Felicitations(nomJoueurs[infosGagnant[0]]);
    }
    else
    {
        Console.WriteLine("Il y a égalité entre les joueurs :");
        for (int k=0;k<casEgalite.Length; k++)
        {
            if (casEgalite[k]==1)
            {
                Console.WriteLine($"Le joueur {k+1}");
                Felicitations(nomJoueurs[k]);
            }
        }
    }
}

void ModeSolo (string[] nomJoueur)
{
    // On créer le tableau initial du joueur et le tableau du joueur
    int nbCartesParUplet =DemanderCartesIndent();
    int nbUplet = DemanderNbUplet();
    int nombreCoupsLimite= NombreCoupsLimite(nbCartesParUplet);
    int[] joueur=new int[1];
    char[,] tableauJoueur = CreerTableauInitial(nbCartesParUplet , nbUplet);
    char[,] plateauSol = NewPlateauSolution(nbCartesParUplet , nbUplet);
    // On créer les variables à utiliser pour les tours du joueur
    int rgCarte=0;
    char[,] tableauTemporaire=CreerTableauInitial(nbCartesParUplet , nbUplet);
    int score =0;
    char[] choixTour = new char[nbUplet+1];
    bool fin =false;
    int[] position = new int[2];
    int nombreCoups=0;
    // Tant que le tableau que du joueur n'est pas encore découvert entièrement on continue  
    do
    {
        // A chaque fois que le joueur recommence à découvrir des nouvelles cartes
        // On réinitialise le rang de la carte, les choix du joueur et le tableau affiché
        rgCarte=0;
        for (int a=0; a<tableauTemporaire.GetLength(0);a++)
        {
            for (int k=0; k<tableauTemporaire.GetLength(1);k++)
            {
                tableauTemporaire[a,k]=tableauJoueur[a,k];
            }
        }             
        for (int j=0; j<choixTour.Length;j++)
        {
            choixTour[j]=' ';
        }
        // Tant que le joueur retourne des cartes identiques et qu'on a pas
        // retourné le nombre de carte égal au nombre de n-uplet on continue 
        while ( rgCarte< nbUplet && VerifieCartes(rgCarte, choixTour)== true && fin ==false )
        {
            // On affiche le tableau et on demande quelle carte le joueur veut retourner
            AfficherTableau(tableauTemporaire);
            position = DemandePositionCartes(tableauTemporaire);
            tableauTemporaire=RetourneCarte(position, tableauTemporaire, plateauSol);
            choixTour[rgCarte]= plateauSol[position[0],position[1]];
            rgCarte++;
        }
        nombreCoups++;
        AfficherTableau(tableauTemporaire);
        // Si le joueur a retourné un n-uplet, on ajoute un au score du joueur
        if (rgCarte==nbUplet && VerifieCartes(rgCarte, choixTour)== true)
        {
            fin= PaireRetourne(tableauTemporaire, tableauJoueur,joueur,nomJoueur[0],-1,fin, plateauSol);
            score++;
            Console.WriteLine($"Félicitations, vous avez retourné un n-uplet.");
            Console.WriteLine($"Vous avez un score de {score}.");
            if (nombreCoupsLimite!=0 && nombreCoupsLimite!=nombreCoups)
                Console.WriteLine($"Il vous reste {nombreCoupsLimite-nombreCoups} coups.");
            Console.WriteLine("Pressez n'importe quel bouton pour continuer.");
            Console.ReadLine();

        }  
        else
        {
            // Si le joueur s'est trompé, on lui laisse le temps de mémoriser les cartes
            Console.WriteLine($"Vous vous êtes trompés.");
            if (nombreCoupsLimite!=0 && nombreCoupsLimite!=nombreCoups)
                Console.WriteLine($"Il vous reste {nombreCoupsLimite-nombreCoups} coups. ");
            Console.WriteLine($"Une fois que vous avez mémorisez les cartes, pressez n'importe que bouton pour continuer.");
            Console.ReadLine();
        }
    }   
    while (fin==false && (nombreCoupsLimite==0 || nombreCoupsLimite>nombreCoups ));  
    if (nombreCoups==nombreCoupsLimite)
    {
        Console.WriteLine(" PERDU !");
        Console.WriteLine(" Vous avez dépassé le nombre de coups limite!");
    }  
    else 
    {
        Console.WriteLine($"Vous avez gagné en {nombreCoups} coups.");    
        Felicitations(nomJoueur[0]); 
    } 
}

void ModeMultijoueur (int nbDeJoueur, string[] nomJoueurs)
{
    // On créer le tableau initial du joueur et le tableau du joueur
    int nbCartesParUplet =DemanderCartesIndent();
    int nbUplet = DemanderNbUplet();
    char[,] tableauJoueur = CreerTableauInitial(nbCartesParUplet , nbUplet);
    char[,] plateauSol = NewPlateauSolution(nbCartesParUplet , nbUplet);
    // On créer les variables à utiliser pour les tours du joueur
    int rgCarte=0;
    char[,] tableauTemporaire=CreerTableauInitial(nbCartesParUplet , nbUplet);
    int[] joueur = new int[nbDeJoueur] ;
    for (int j=0; j<joueur.Length;j++)
    {
        joueur[j]=0;
    }
    char[] choixTour = new char[nbUplet+1];
    bool fin =false;
    int[] position = new int[2];
    // Tant que le tableau que du joueur n'est pas encore découvert entièrement
    // On fait jouer chaque joueur les uns après les autres
    while(fin == false)
    {
        for (int i=0; i<joueur.Length;i++)
        {
            // On vérifie que le tableau n'est pas entièrement retourné
            if ( fin ==false)
            {
                // Entre chaque tour, on réinitialise le nombre de carte retournée, 
                //  le tableau du joueur et les choix de cartes faits ce tour
                Console.WriteLine($"C'est au tour du joueur {i+1}");
                // Tant que le joueur réussit à découvrir des n-uplets
                // On lui demande de continuer à retourner des cartes
                do
                {
                    // A chaque fois que le joueur recommence à découvrir des nouvelles cartes
                    // On réinitialise le rang de la carte et les choix du joueur
                    rgCarte=0;
                    for (int a=0; a<tableauTemporaire.GetLength(0);a++)
                    {
                       for (int k=0; k<tableauTemporaire.GetLength(1);k++)
                        {
                            tableauTemporaire[a,k]=tableauJoueur[a,k];
                        }
                    }
                    
                    for (int j=0; j<choixTour.Length;j++)
                    {
                        choixTour[j]=' ';
                    }
                    // Tant que le joueur retourne des cartes identiques et qu'on a pas
                    // retourné le nombre de carte égal au nombre de n-uplet on continue 
                    while ( rgCarte< nbUplet && VerifieCartes(rgCarte, choixTour)== true && fin ==false )
                    {
                        // On affiche le tableau et on demande quelle carte le joueur veut retourner
                        AfficherTableau(tableauTemporaire);
                        position = DemandePositionCartes(tableauTemporaire);
                        tableauTemporaire=RetourneCarte(position, tableauTemporaire, plateauSol);
                        choixTour[rgCarte]= plateauSol[position[0],position[1]];
                        rgCarte++;
                    }
                    AfficherTableau(tableauTemporaire);
                    // Si le joueur a retourné un n-uplet, on ajoute un au score du joueur
                    if (rgCarte==nbUplet && VerifieCartes(rgCarte, choixTour)== true)
                    {
                        fin= PaireRetourne(tableauTemporaire, tableauJoueur,joueur,nomJoueurs[i],i,fin, plateauSol);
                    }  
                    else
                    {
                        // Si le joueur s'est trompé, on lui laisse le temps de mémoriser les cartes avant de passer au joueur suivant
                        Console.WriteLine($"Le joueur {i+1} n'a pas réussit. C'est au tour du joueur suivant.");
                        Console.WriteLine($"Une fois que vous avez mémorisez les cartes, pressez n'importe que bouton pour continuer,.");
                        Console.ReadLine();

                    }
                }
                while (rgCarte==nbUplet && VerifieCartes(rgCarte, choixTour)== true &&  fin==false );               
            }
        }
    }
    DeterminationGagnantEtMessage(joueur, nomJoueurs);
}

void ModeIA (string[] nomJoueurs)
{
    // Le mode IA prend en paramètre le nom du joueur(nomJoueur[0]) et de l'IA (nomJoueur[1])
    // Et les font jouer l'un contre l'autre
    // On créer le tableau initial du joueur et le tableau du joueur
    int nbCartesParUplet =DemanderCartesIndent();
    int nbUplet = DemanderNbUplet();
    char[,] tableauJoueur = CreerTableauInitial(nbCartesParUplet , nbUplet);
    char[,] plateauSol = NewPlateauSolution(nbCartesParUplet , nbUplet);
    // On créer les variables à utiliser pour les tours du joueur
    int rgCarte=0;
    char[,] tableauTemporaire=CreerTableauInitial(nbCartesParUplet , nbUplet);
    int[] joueur = new int[] {0,0};
    char[] choixTour = new char[nbUplet+1];
    bool fin =false;
    int[] position = new int[2];
    // Tant que le tableau que du joueur n'est pas encore découvert entièrement
    // On fait jouer chaque joueur les uns après les autres
    while(fin == false)
    {
        for (int i=0; i<2;i++)
        {
            // On vérifie que le tableau n'est pas entièrement retourné
            // Quand i=0 c'est le tour du joueur
            // Quand i=1, c'est le tour de l'IA
            if ( fin ==false)
            {
                // Entre chaque tour, on réinitialise le nombre de carte retournée, 
                //  le tableau du joueur et les choix de cartes faits ce tour
                Console.WriteLine($"C'est au tour de {nomJoueurs[i]}");
                // Tant que le joueur réussit à découvrir des n-uplets
                // On lui demande de continuer à retourner des cartes
                do
                {
                    // A chaque fois que le joueur recommence à découvrir des nouvelles cartes
                    // On réinitialise le rang de la carte et les choix du joueur
                    rgCarte=0;
                    for (int a=0; a<tableauTemporaire.GetLength(0);a++)
                    {
                       for (int k=0; k<tableauTemporaire.GetLength(1);k++)
                        {
                            tableauTemporaire[a,k]=tableauJoueur[a,k];
                        }
                    }
                    
                    for (int j=0; j<choixTour.Length;j++)
                    {
                        choixTour[j]=' ';
                    }
                    // Tant que le joueur retourne des cartes identiques et qu'on a pas
                    // retourné le nombre de carte égal au nombre de n-uplet on continue 
                    if (i==0)
                    {
                        // Instructions pour le joueur
                        while ( rgCarte< nbUplet && VerifieCartes(rgCarte, choixTour)== true && fin ==false )
                        {
                            // On affiche le tableau et on demande quelle carte le joueur veut retourner
                            AfficherTableau(tableauTemporaire);
                            position = DemandePositionCartes(tableauTemporaire);
                            tableauTemporaire=RetourneCarte(position, tableauTemporaire, plateauSol);
                            choixTour[rgCarte]= plateauSol[position[0],position[1]];
                            rgCarte++;
                        }
                        AfficherTableau(tableauTemporaire);
                    }
                    else 
                    {
                        // Instructions pour faire fonctionner l'IA
                        while ( rgCarte< nbUplet && VerifieCartes(rgCarte, choixTour)== true && fin==false )
                        {
                            // On affiche le tableau et on demande montre les cartes qur l'IA va retourner
                            position = CartesPatates(tableauTemporaire);
                            tableauTemporaire=RetourneCarte(position, tableauTemporaire, plateauSol);
                            choixTour[rgCarte]= plateauSol[position[0],position[1]];
                            rgCarte++;
                            AfficherTableau(tableauTemporaire);
                        }
                    }
                    // Si le joueur a retourné un n-uplet, on ajoute un au score du joueur
                    if (rgCarte==nbUplet && VerifieCartes(rgCarte, choixTour)== true)
                    {
                        fin= PaireRetourne(tableauTemporaire, tableauJoueur,joueur,nomJoueurs[i],i,fin, plateauSol);
                    }  
                    else if (rgCarte==nbUplet && VerifieCartes(rgCarte, choixTour)== false)
                    {
                        // Si le joueur s'est trompé, on lui laisse le temps de mémoriser les cartes avant de passer au joueur suivant
                        Console.WriteLine($"{nomJoueurs[i]} n'a pas réussit. C'est au tour du joueur suivant.");
                        Console.WriteLine($"Une fois que vous avez mémorisez les cartes, pressez n'importe que bouton pour continuer.");
                        Console.ReadLine();

                    }
                }
                while (rgCarte==nbUplet && VerifieCartes(rgCarte, choixTour)== true &&  fin==false );               
            }
        }
    }
    if (joueur[0]>joueur[1])
    {
        Felicitations(nomJoueurs[0]);
    }
    else if (joueur[0]==joueur[1])
    {
        Console.WriteLine("Vous êtes à égalité avec l'IA");
    }
    else
    {
        Console.WriteLine("PERDU !");
        Console.WriteLine("Vous avez perdu contre l'IA");
    }
}

//ESSAI 
void Jeux ()
{
    // Voici la fonction qui permet de joueur au mémory
    // Elle initialise le mode de jeux et demande aux joueurs le mode qu'il veut jouer
    // Puis elle demande le(s) prénom(s) du/des joueurs et lance le mode de jeux choisit

    int choixMode=choixModeDeJeu ();
    string[] nomJoueur=DetermineNbJoueurs(choixMode);
    demandeNomJoueur(choixMode, nomJoueur);
    if (choixMode==1)
    {
        ModeSolo(nomJoueur);
    }
    else if (choixMode ==2)
    {
        ModeMultijoueur(nomJoueur.Length ,nomJoueur);
    }
    else // choixMode==3 
    {
        ModeIA(nomJoueur);
    }   
}
Jeux();
