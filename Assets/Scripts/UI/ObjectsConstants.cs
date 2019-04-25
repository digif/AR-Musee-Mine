using System.Collections.Generic;
using UnityEngine;

public class ObjectsConstants
{
    public static List<Info> infos;

    /// <summary>
    /// fill up the list with the items descriptions
    /// </summary>
    public static void Initialize()
    {
        infos = new List<Info>();
        infos.Add(new Info("Image Grisoumetre", "Grisoumètre",  "Le Grisoumètre est un appareil servant à mesurer le taux de grisou dans une mine. Il s'agit le plus souvent d'un instrument permettant de mesurer la teneur en grisou dans l'air ambiant, estimée principalement selon la hauteur d'une flamme."));
        infos.Add(new Info("Image Briquet",     "Briquet",      "Outil qui permet de générer une petite flamme pour allumer une cigarette ou pour permettre au pénitant d'allumer une mèche. Cette mèche est située au bout d'une longue perche qui permet de faire exploser le grisou."));
        infos.Add(new Info("Image Genephone",   "Genephone",    "Le généphone fonctionne simplement avec deux fils pour relier les combinés. Il génère (d'où son nom) lui-même sa propre électricité de fonctionnement."));
        infos.Add(new Info("Image Chaussures",  "Chaussures",   "Chaussures spécialement faites pour les mineurs. Elles sont renforcées pour protéger les pieds des mineurs."));
        infos.Add(new Info("Image Lampisterie", "Lampisterie",  "Atelier, local où l'on range, comptabilise, entretient et répare les lampes portatives et les lanternes (dans une collectivité, une entreprise, une mine)."));
        infos.Add(new Info("Image Pelle",       "Pelle",        "Outil qui permettait aux mineurs de charger le charbon dans les berlines."));
        infos.Add(new Info("Image Pioche",      "Pioche",       "Utilisé par le « piqueur » il joue un grand rôle, car il permet de piocher dans la mine pour en prendre le charbon."));
        infos.Add(new Info("Image Casque",      "Casque",       "Dans les années cinquante, les casques en résine époxy ou en plastique ont remplacé les anciennes barrettes. Ces casques épais offraient une meilleure protection et étaient équipés pour recevoir la lampe électrique « au chapeau »." ));
        infos.Add(new Info("Image Bidon1",      "Bidon 1",      "Outil permettant aux mineurs de transporter des liquides."));
        infos.Add(new Info("Image Bidon2",      "Bidon 2",      "Outil permettant aux mineurs de transporter des liquides."));
        infos.Add(new Info("Image Burette1",    "Burette 1",    "Petit flacon à goulot (spécialement : prolongé d'un tube étroit pour verser goutte à goutte)." ));
        infos.Add(new Info("Image Burette2",    "Burette 2",    "Petit flacon à goulot"));
        infos.Add(new Info("Image Burin",       "Burin",        "Outil en forme de ciseau d’acier que l’on pousse à la main et qui sert à graver, à couper les métaux. L’outillage du mineur (burin, coin, pointerolle, pic, masse) devait être entretenu quotidiennement pour conserver son efficacité." ));
        infos.Add(new Info("Image Cle",         "Clé",          "Outil très classique utilisé même par les mineurs."));
        infos.Add(new Info("Image Gourde",      "Gourde",       "Permet au mineur de boire en service pour se rafraichir."));
        infos.Add(new Info("Image Lampe",       "Lampe",        "Meilleur ami du mineur puisqu'il lui permet tout simplement de voir !"));
        infos.Add(new Info("Image Pot",         "Pot",          "Outil qui permettait aux mineurs de transporter avec eux un liquide."));
        infos.Add(new Info("Image Hache",        "Hache",       "Outil utilisé dans les mines pour tailler les renforcements en bois."));
    }
}
