﻿internal enum Color {
    BLACK
}

internal class Program {
    private static void Main(string[] args) {
        if( Color.BLACK == 0 )
            Console.WriteLine((true? "true": "flase"));

    }
}