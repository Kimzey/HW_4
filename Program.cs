using System;

class Program
{
    public static Tree<string> rank = new Tree<string>();
    public static Stack<string> stackuser = new Stack<string>();


    public static string InputName(){
        string name = Console.ReadLine();
        return name;
    }
    public static int InputNumber(){
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    public static void PushTree(string inputname){
        
        int number = InputNumber();
        if(number != 0){
            
            string name1 = InputName();
            rank.AddChildX(inputname,name1);
            PushTree(name1);
            stackuser.Push(name1);

            if(number >= 1){
                for(int i = 1 ;i < number ; i++){
                    string name2 = InputName();
                    rank.AddSiblingX(stackuser.Pop(),name2);
                    PushTree(name2);
                    stackuser.Push(name2);
                }
            }

        }
    }

    public static int Output (string final){//ไว้แปลง สติง เป็น index
        for(int i = 0; i<rank.GetLength();i++){
            if(final == rank.Get(i)){
                return i;
            }
        }
        return 0;
    }

    static void Main(string[] args)
    {
        //ทำโดยการแก้+เพิ่ม Tree / Tree Node
        if(rank.GetLength() == 0){
            string name = InputName();
            rank.AddChild(-1,name);
            PushTree(name);
        }
        Console.WriteLine("____________________________________________________");
        Console.Write("Input : ");
        string final = Console.ReadLine();

        Console.WriteLine("____________________________________________________");
        Console.WriteLine("Output :");

        Stack<string> stacksearch =  rank.GetStackpreson(Output(final));

        while(true){
            if(stacksearch.GetLength() == 0){
                break;
            }
            else{
                Console.WriteLine(stacksearch.Pop());
            }
        }

        //ไว้เช็คในคนใน tree
        // Console.WriteLine("Welcome to loop for Tree");
        // for(int i =0 ; i < rank.GetLength() ; i++){
        //     //Console.WriteLine(rank.GetX("kim1"));
        //     Console.WriteLine(rank.Get(i));
        // }
    }
}
