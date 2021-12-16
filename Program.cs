using System;
using System.Collections.Generic;

namespace OrderingGoods
{
    class Program
    {
        static List<char> ProcessingLine = new List<char>(); // ไว้เก็บชิ้นส่วนที่รอการประกอบ
        static Stack<char> TemporaryStoreLine = new Stack<char>(); //ไว้เก็บส่วนที่เกินจาก ProcessingLine
        static int FinishedProducts = 0; // จำนวนสินค้าที่ประกอบเสร็จแล้ว

        static void Main(string[] args)
        {
            int NumofDesireProducts = int.Parse(Console.ReadLine());  // กรอกจำนวนสินค้าที่ต้องการ

            InsertParts(NumofDesireProducts);

            Console.WriteLine("");
            Console.WriteLine("All leftover parts:"); // โชว์ชิ้นส่วนทั้งหมดที่เหลือหลังจากที่ประกอบครบตามจำนวนที่ต้องการแล้ว

            foreach(char Leftover in ProcessingLine)
            {
                Console.WriteLine(Leftover);
            }
            foreach (char Leftover in TemporaryStoreLine)
            {
                Console.WriteLine(Leftover);
            }
        }

        static void InsertParts(int NumofDesireProducts)
        {
            do
            {
                char Parts = char.Parse(Console.ReadLine());  // กรอกชื่อชิ้นส่วนที่นำเข้ามาจากสายการผลิต

                CheckParts(Parts);

            } while (NumofDesireProducts != FinishedProducts); // กรอกจนว่าจำนวนสินค้าที่ต้องการจะเท่ากับจำนวนสินค้าที่ผลิตได้
        }

        static void CheckParts(char Parts)
        {
            if (ProcessingLine.Contains(Parts)) // ถ้าชิ้นส่วนที่นำเข้ามาซ้ำกับที่มีใน ProcessingLine
            {
                TemporaryStoreLine.Push(Parts); // ก็ให้ไปใส่ใน TemporaryStoreLine
            }
            else
            {
                ProcessingLine.Add(Parts); // ถ้าไม่ซ้ำก็ไปใส่ใน ProcessingLine แทน
            }

            if (ProcessingLine.Contains('A') && ProcessingLine.Contains('B') && ProcessingLine.Contains('C') && ProcessingLine.Contains('D') && ProcessingLine.Contains('E'))
            {
                ProcessingLine.Clear(); // ถ้าใน ProcessingLine มีครบ ABCDE แล้วก็ให้โละชิ้นส่วนออกให้หมด
                FinishedProducts++; // จำนวนสินค้าที่ผลิตได้ + 1

                for (int i = 1; i <= TemporaryStoreLine.Count; i++)
                {
                    CheckParts(TemporaryStoreLine.Pop()); // นำสินค้าใน TemporaryStoreLine ทั้งหมดออกมาคำนวนใหม่อีกครั้งเพราะตอนนี้ใน ProcessingLine โล่งแล้ว
                }
            }
        }
    }
}
