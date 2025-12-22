//Fråga 1
class Item
{
    public int age;
}

public class ItemHandler
{
    private Item[] items;

    public ItemHandler()
    {
        items = new Item[12];
        Random random = new Random();
        for (int i = 0; i <= items.Length; i++)
        {
            items[i] = new Item();
            items[i].age = random.Next() % 58;
        }
    }

    public void AgeItems()
    {
        foreach (var item in items)
        {
            item.age += 1;
        }
    }
}

//Fråga 2
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>()
        {
            0,3,1,4,2,5,0,6,1,7,2,8,0,9,1,10  
        };

        foreach (int number in numbers)
        {
            Console.Write($"{number}, ");
        }
        
        
        /*ChatGPT lösning
        int a = 0;
        int b = 3;

        
        for (int i = 0; i < 7; i++)
        {
            Console.Write(a + ", ");
            Console.Write(b + ", ");

            a = (a + 1) % 3;
            b++;
        }

        Console.Write(a + ", ");
        Console.Write(b);*/
    }
}

//Fråga 3
/*En LinkedList har mycket mer dynamisk längd än en lista och
//är mycket lättare att sätta in och ta ut första och sista värdet
Däremot så är en linkedlist svårare på få tag på index på sina värden vilket en vanlig lista är bättre på.*/

//Fråga 4
/*A) Ett spritesheet är i grund och botten massa bilder av samma storlek (exemeplvis 64x64) ihop sagt till en större bild
 för senare användning. Det kan exempel vara olika bilder för olika sorts vägar som sedan kan läggas ihop för att skapa en karta
 för spelet
 B) Man skulle kunna ha en bool som returnerar sant när man går. Exemeplvis isWalking. Och när den returnerar
 sant så byter koden mellan två eller fler bilder av huvudkaraktären med hjälp av deltaTime. Man kan också lägga till
 en delay om man vill ha mindre frekvent byte. Sedan så byter den emellan bilderna oändligt*/
 
 //Fråga 5
 class Character
 {
     public void Update(float deltaTime)
     {
         
     }
 }

 class NPC : Character
 {
     public bool Interactable;
     protected NPCBehaviour behaviour;
     
     //B
     public NPC(bool interactable, NPCBehaviour behaviour)
     {
         Interactable = interactable;
         this.behaviour = behaviour;
     }
 }

 class NPCBehaviour
 {
     public void TakeAction()
     {
         
     }
 }