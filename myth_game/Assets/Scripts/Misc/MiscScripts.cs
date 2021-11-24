using Random = System.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscScripts : MonoBehaviour
{

    static string[] randomNames =
    {
        "Garry Cortes"
        ,"Carlo Guerra"
        ,"Fateh Rees"
        ,"Nathan Horton"
        ,"Hajra Spears"
        ,"Gabriela Spooner"
        ,"Sadiyah Bishop"
        ,"Gary Thatcher"
        ,"Juno Moon"
        ,"Harrison Wharton"
        ,"Husnain Pike"
        ,"Zaine Nicholls"
        ,"Daanyal Stubbs"
        ,"Alisa Salter"
        ,"Niam Ellison"
        ,"Stefania Branch"
        ,"Lily-Anne Rivas"
        ,"Ishaaq Copeland"
        ,"Imaan Lancaster"
        ,"Angelica Hartley"
        ,"Mattie Rodgers"
        ,"Felix Haley"
        ,"Amrita Mcgrath"
        ,"Clarice Salgado"
        ,"Amos Hall"
        ,"Umaima Rangel"
        ,"Shanon Brooks"
        ,"Aneesa Mcdowell"
        ,"Karan Sanderson"
        ,"Umayr Markham"
        ,"Kristofer Britt"
        ,"Rosina Lopez"
        ,"Drake Clarkson"
        ,"Humaira Simpson"
        ,"Emmett Bouvet"
        ,"Darlene Carrillo"
        ,"Yusuf Sargent"
        ,"Menaal Zhang"
        ,"Ida Coombes"
        ,"Malia Coulson"
        ,"Olivia-Mae Mcmahon"
        ,"Viktor Fernandez"
        ,"Aurelia Oliver"
        ,"Paulina Sanford"
        ,"Roberto Whittle"
        ,"Ines Cortez"
        ,"Conner Barker"
        ,"Liana Mullins"
        ,"Anna Penn"
        ,"Dotty Appleton"
        ,"Amiya Adkins"
        ,"Akshay Hodson"
        ,"Heena Brandt"
        ,"Emilie Benitez"
        ,"Elif Shannon"
        ,"Tiernan Maldonado"
        ,"Nur Burt"
        ,"Moshe Puckett"
        ,"Rudy Bannister"
        ,"Tallulah Sosa"
        ,"Clarissa Buckner"
        ,"Clementine Clay"
        ,"Libby Walmsley"
        ,"Dania Mcdonald"
        ,"Jude Kennedy"
        ,"Edmund Vance"
        ,"Kai Oneal"
        ,"Maureen Ahmad"
        ,"Lillia Bowen"
        ,"Cataleya Dean"
        ,"Zidan Huynh"
        ,"Nia Hendricks"
        ,"Lamar Jaramillo"
        ,"Murphy Smith"
        ,"Dafydd Xiong"
        ,"Herbie Sheehan"
        ,"Om Yoder"
        ,"Aoife Drake"
        ,"Micah Cardenas"
        ,"Iris Becker"
        ,"Sheikh Whitney"
        ,"Rafi Rankin"
        ,"Kenny Travis"
        ,"Edith Michael"
        ,"Beau Sparks"
        ,"Gertrude Edwards"
        ,"Phillipa Oakley"
        ,"Abdur Barry"
        ,"Arsalan Betts"
        ,"Sofija Salt"
        ,"Owain Naylor"
        ,"Angharad Parry"
        ,"Safiya Firth"
        ,"Arbaaz Cox"
        ,"Sheila Braun"
        ,"Isobel Gentry"
        ,"Dylon Mcfarland"
        ,"Inaayah Strickland"
        ,"Eamon Townsend"
        ,"Laurel Preston"


    };
    public static string GeneratePresetName()
    {
        Random r = new Random();
        return randomNames[r.Next(0, 99)];
    }

    public static string GenerateName(int len)
    {
        Random r = new Random();
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        string Name = "";
        Name += consonants[r.Next(consonants.Length)].ToUpper();
        Name += vowels[r.Next(vowels.Length)];
        int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
        while (b < len)
        {
            Name += consonants[r.Next(consonants.Length)];
            b++;
            Name += vowels[r.Next(vowels.Length)];
            b++;
        }

        return Name;


    }
}

