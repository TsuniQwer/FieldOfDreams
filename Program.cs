
using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading;


namespace С_
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            int points = 0; 
            int trys = 0;
            string user = "";
            bool CheckWordAnswerUser = true;
            int difficultyLevel;
            bool checkTrys = true;
            bool hardDifficulty = false;
            

            Random rnd = new Random();

            

            string[] words = {"изумруд" ,"мост","жилище","мозг","пилка", "коллега","капрал","кварц", "бункер","мученик",
                            "палка","мышка","алхимия", "паспорт", "котлета", "тюлень", "бронежилет", "медведь", 
                            "прут", "лосось", "мусор", "карабин", "заповедник", "плед", "букашка", "авиакомпания"};
            
            string[] prompts = {"Руда","Является одним из древнейших инженерных изобретений человечества",
                            "Первоначально это были различные пещеры, гроты и пр.","Центральный отдел нервной системы",
                            "Маленький напильник", "Товарищ по учению или работе","Младший командир в армиях",
                            "Один из самых распространённых минералов в земной коре",
                            "Хорошо укреплённое защитное или оборонительное сооружение",
                            "Персонаж античной трагедии, который претерпел невыносимые страдания", "Длинный прямой предмет",
                            "Устройство ввода","У средневековых мистиков: изыскание способов превращать простые металлы в драгоценные при помощи не существующего \nв природе, фантастического философского камня, поиски эликсира долголетия.",
                            "Официальный документ","Рубленный фарш в виде толстой лепешки или пирожка",
                            "Морское ластоногое млекопитающее животное","Средство индивидуальной защиты человека",
                            "Хищное млекопитающее","Тонкий стержень", "Один из самых популярных наших продуктов",
                            "Предметы, выброшенные человеком или вынесенные ветром, которые находятся там в 'плавающем' состоянии.",
                            "Класс стрелкового оружия", "Участок территории (акватории), на котором сохраняется в естественном состоянии весь его природный комплекс.",
                            "Клетчатая толстая шерстяная шаль с бахромой","Мелкое насекомое","Услуги воздушного транспорта для путешествующих пассажиров и грузов"};

            int num_word = rnd.Next(words.Length);
            string randomWord = (words[num_word]);       // ЗАГАДАННОЕ СЛОВО
            string randomPrompt = (prompts[num_word]);  // ПОДСКАЗКА
            string[] playerWord = new string[randomWord.Length]; // УГАДАННЫЕ БУКВЫ ИГРОКА

            int d = 0; // ?

           

            System.Console.WriteLine("Слово загадано.\n");
            //System.Console.WriteLine(randomWord);
            Thread.Sleep(1500); // мс

            //* УРОВЕНЬ СЛОЖНОСТИ 
            try
            {
                System.Console.WriteLine("Выбери уровень сложности: \nлегко(1), нормально(2), сложно(3), ХАРДКОР(4)");
                difficultyLevel = Convert.ToInt32(Console.ReadLine());

                switch(difficultyLevel){
                    case 1:
                        difficultyLevel = 0; // легко
                        break;
                    case 2:
                        difficultyLevel = 1; // нормально
                        break;
                    case 3:
                        difficultyLevel = 2; // сложно
                        break;
                    case 4:
                        difficultyLevel = 2; // хардкор
                        hardDifficulty = true;
                        break;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n"+e.Message);
                System.Console.WriteLine("Press any key..");
                Console.ReadLine();
                Main(args);
                throw;
            }
            

            //* ПОДСКАЗКА

            if (hardDifficulty != true)
            {
                System.Console.WriteLine("\nПодсказка: "+ randomPrompt);
                Thread.Sleep(3800); // мс
            }
    
            foreach (int i in randomWord) {System.Console.Write("*");}

            System.Console.WriteLine($" | в слове " + randomWord.Length + " букв.");
            
            //TODO ИГРОК НАЗЫВАЕТ СЛОВО ИЛИ КРУТИТ БАРАБАН

            try
            {
                while (user != "1" || user != "2"){
                
                // У ИГРОКА ЗАКОНЧИЛСЬ ПОПЫТКИ НАЗЫВАТЬ СЛОВО
                if (trys == randomWord.Length - difficultyLevel){
                    System.Console.WriteLine($"\nТы проиграл, это было слово '{randomWord}'. \nУ тебя закончились попытки отгадать слово! :(\nты набрал {points} очков.");
                    return;

                }

                
                System.Console.WriteLine("Назвать слово(1) или крутить барабан(2)");
                user = Console.ReadLine();
                // НАЗЫВАЕТ СЛОВО
                if (user == "1" ) 
                {
                    
                    // ИГРОК НАЗЫВАЕТ СЛОВО
                    if (CheckWord(ref randomWord, ref CheckWordAnswerUser) == true) {

                        
                        System.Console.WriteLine($"\nТы победил! :DD\nи набрал {points} очков.");
                        return;
                    }
                    else {
                        System.Console.WriteLine($"\nТы проиграл! :(\nЭто было слово '{randomWord}'. \nТы набрал {points} очков.");
                        return;
                    }
                }
                // ИГРОК КРУТИТ БАРАБАН
                else if (user == "2") {Baraban(ref points, ref randomWord, ref checkTrys, ref playerWord, ref d);}

                if (checkTrys == false) {trys += 1;}
                
            }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n"+e.Message);
                System.Console.WriteLine("Press any key..");
                Console.ReadLine();
                Main(args);
                throw;
            }

            
            
        }
        
        
        // *КРУТИТЬСЯ БАРАБАН
        static void Baraban(ref int points, ref string randomWord, ref bool checkTrys, ref string[] playerWord, ref int d){   
            
            int[] point = {0,900,400,800,600,1500,1000,700,200,300,500};

            Random rnd = new Random();
            int num_point = rnd.Next(point.Length);
            int randomPoint = (point[num_point]);
            points += randomPoint;
            System.Console.WriteLine("Крутиться барабан...");
            System.Console.WriteLine($"На барабане: {randomPoint} очков.");
            AnswerkLatter(ref randomWord, ref checkTrys, ref playerWord, ref d);
            
        }

        //TODO ИГРОК НАЗЫВАЕТ БУКВУ 
        static void AnswerkLatter(ref string randomWord, ref bool checkTrys, ref string[] playerWord,ref int d){
            d++;
            System.Console.WriteLine("\nВаша буква? ...");
            string userLetter = Console.ReadLine().ToLower();

            while (userLetter.Length > 1){

                System.Console.WriteLine("\nВаша буква? ...");
                userLetter = Console.ReadLine().ToLower();
            }

            char chrUser = char.Parse(userLetter);
            if (CheckLatter(ref randomWord, ref chrUser) == true){
                //ПРОВЕРКА БУКВЫ В МАСИВЕ 
                
                for (int i = 0; i < playerWord.Length; i++) 
                {
                    if (playerWord[i] == userLetter) {
                        Thread.Sleep(800); // мс
                        System.Console.WriteLine("Такая буква уже есть!"); // ?
                        checkTrys = false;
                        AnswerkLatter(ref randomWord, ref checkTrys, ref playerWord, ref d);
                        return;
                    }

                    else if (playerWord[i] != userLetter && i+1 == playerWord.Length) {

                        // ДОБАВЛЯЕМ БУКВУ В МАССИВ ЕСЛИ ЕЕ ТАМ НЕТ
                        playerWord[randomWord.IndexOf(userLetter)] += userLetter;
                        break;  
                      
                    }
                    
                }

                checkTrys = true;
                Thread.Sleep(1800); // мс
                System.Console.WriteLine("Есть такая буква!\n");
                foreach (string item in playerWord)
                {
                    System.Console.WriteLine("> "+item + " ");
                }
                
                

                //ВСЕ ОТГАДАННЫЕ БУКВЫ ИГРОКА
                
            }
                

            else {
                checkTrys = false;
                Thread.Sleep(1800); // мс
                System.Console.WriteLine("Нет такой буквы.");
                
                }

            
        }
        //?ПРОВЕРКА ПРАВИЛЬНОСТИ БУКВЫ ИГРОКА

        static bool CheckLatter(ref string randomWord,ref char chrUser){
            
            
            if (randomWord.ToLower().Contains(chrUser)) {return true;}
            else {return false;}
        }

        //?ПРОВЕРКА ПРАВИЛЬНОСТИ СЛОВО ИГРОКА
        static bool CheckWord(ref string randomWord, ref bool CheckWordAnswerUser){
            try
            {
                System.Console.WriteLine("\nЭто слово: ");
                string WordAnswerUser =  Console.ReadLine();

                if (randomWord == WordAnswerUser.ToLower()) {return true;}
                else  {return false;}  
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n"+e.Message);
                System.Console.WriteLine("Press any key..");
                CheckWord(ref randomWord, ref CheckWordAnswerUser);
                Console.ReadLine();
                throw;
            }
            
            
        }


        //* БОТ
        static string Bot(ref string randomWord) => "";    
        
        
    }
}
