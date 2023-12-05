// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <fstream>
#include <sstream>
#include <memory>

size_t line_length;
size_t number_of_lines;
std::unique_ptr<char[]> lines{};

std::stringstream ss;

size_t left = 0;
size_t right = 0;
size_t num = 0;
size_t sum = 0;

bool buildingNumber = false;

bool checkPos(size_t row, size_t col)
{
   if (row < 0)
   {
      return false;
   }
   if (row > number_of_lines - 1)
   {
      return false;
   }
   if (col < 0)
   {
      return false;
   }
   if (col > line_length)
   {
      return false;
   }
   char ch = lines[row * (line_length + 2) + col];

   //*
   // Part 1
   if (ch!='.' && !std::isdigit(ch))
   {
       return true;
   }
   /*/
   // Part 2
   if (lines[row][col] == '*') 
   {
      x = row;
      y = col;
      return true;
   }
   //*/
   return false;
}

bool checkNumber(size_t left, size_t right, size_t line)
{
   for (size_t i = left - 1; i <= right + 1; ++i)
   {
      // Check line above
      if (checkPos(line - 1, i))
      {
         return true;
      }
      // check line below
      if (checkPos(line + 1, i))
      {
         return true;
      }
   }
   if (checkPos(line, left - 1))
   {
      return true;
   }
   if (checkPos(line, right + 1))
   {
      return true;
   }
   return false;
}

void check(size_t i, size_t j)
{
   right = i - 1;
   num = stoi(ss.str());

   if (checkNumber(left, right, j))
   {
      sum += num;
      std::cout << ss.str() << ",";
   }
   buildingNumber = false;

   ss.str(std::string());
}

void readFile()
{
   std::ifstream ifs("C:\\NEw\\aoc.txt", std::ios::binary);

   ifs.seekg(0, std::ios::end);
   size_t length_of_the_file = ifs.tellg();
   ifs.seekg(0, std::ios::beg);

   lines = std::make_unique<char[]>(length_of_the_file);

   ifs.read(lines.get(), length_of_the_file);
   for (int i = 0; i < length_of_the_file; i++)
   {
      if (lines[i] == '\r')
      {
         line_length = i;
         break;
      }
   }

   number_of_lines = length_of_the_file / (line_length + 1);

   for (int j = 0; j < number_of_lines; ++j)
   {
      if (buildingNumber)
      {
         check(line_length, j);
      }
      for (int i = 0; i < line_length; ++i)
      {
         char ch = lines[j * (line_length + 2) + i];
         if (std::isdigit(ch))
         {
            if (!buildingNumber)
            {
               buildingNumber = true;
               left = i;
            }
            ss << ch;
         }
         else
         {
            if (buildingNumber)
            {
               check(i, j);
            }
         }
      }
   }
   std::cout << std::endl << sum;
}


int main()
{
   readFile();
}
