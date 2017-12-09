using System;

namespace Basic13
{
    class Program
    {
        public static void printTo255(){
            for(int i=1; i<=255; i++){
                System.Console.WriteLine(i);
            }
        }

        public static void printOddsTo255(){
            for(int i=1; i<=255; i+=2){
                System.Console.WriteLine(i);
            }
        }

        public static void printSum(){
            int sum = 0;
            for(int i=0; i<255; i++){
                System.Console.WriteLine("New Number: {0} Sum: {1}", i, sum);
                sum += i;
            }
        }

        public static void iterateArr(int[] arr){
            foreach(int x in arr){
                System.Console.WriteLine(x);
            }
        }

        public static int findMax(int[] x){
            int max = x[0];
            for(int i=0; i<x.Length-1;i++){
                if(x[i]> max){
                    max = x[i];
                }
            }
            return max;
        }

        public static int findAvg(int[] x){
            int avg = 0;;
            for(int i=0; i<x.Length-1;i++){
                avg += x[i];
            }
            return avg/x.Length;
        }

        public static int[] genOdds(){
            int[] y = new int[255];
            int odd = 1;
            for(int i=1; i<255; i++){
                y[i]=odd;
                odd++;
            }
            foreach(int x in y){
                System.Console.WriteLine(x);
            }
            return y;
        }

        public static int greaterThan(int[] arr, int x){
            int gt = 0;
            foreach(int o in arr){
                if(o>x){
                    gt++;
                }
            }
            return gt;
        }

        public static void squareVals(int[] arr){
            for(int x=0; x<arr.Length; x++){
                arr[x] = arr[x]*arr[x];
            }

            foreach(int o in arr){
                System.Console.WriteLine(o);
            }
        }

        public static void noNegs(int[] arr){
            for(int x=0; x<arr.Length; x++){
                if(arr[x]<0){
                    arr[x]=0;
                }
            }

            foreach(int o in arr){
                System.Console.WriteLine(o);
            }
        }

        public static void minMaxAvg(int[] arr){
            int max = arr[0];
            int min = arr[0];
            double avg = 0;

            foreach(int x in arr){
                if(x > max){
                    max = x;
                }
                if(x < min){
                    min = x;
                }
                avg += x;
            }
            System.Console.WriteLine("Min: {0}, Max: {1}, Average: {2}", min, max, (avg/arr.Length));
        }

        public static void shiftVals(int[] arr){
            for(int x=0; x<arr.Length; x++){
                if(x==arr.Length-1){
                    arr[x]=0;
                } else{
                    arr[x]=arr[x+1];
                }
            }

            foreach(int o in arr){
                System.Console.WriteLine(o);
            }
        }

        public static object[] numToString(int[] arr){
            object[] newArr = new object[arr.Length];
            for(int x=0; x<arr.Length; x++) {
                if (arr[x] < 0){
                    newArr[x] = "Dojo";
                } else {
                    newArr[x] = arr[x];
                }
            }

            // foreach(object o in newArr){
            //     System.Console.WriteLine(o);
            // }
            System.Console.WriteLine(string.Join(",",newArr));
            return newArr;
        }

        static void Main(string[] args)
        {
            // printTo255();
            // printOddsTo255();
            // printSum();
            int[] tacos = {1,4,7,8,2,-1,333, 8};
            // iterateArr(tacos);
            // System.Console.WriteLine(findMax(tacos));
            // System.Console.WriteLine(findAvg(tacos));
            // System.Console.WriteLine(genOdds());
            // System.Console.WriteLine(greaterThan(tacos, 3));
            // squareVals(tacos);
            // noNegs(tacos);
            // minMaxAvg(tacos);
            // shiftVals(tacos);
            numToString(tacos);
        }
    }
}
