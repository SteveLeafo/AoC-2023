{

                            Online Pascal Compiler.
                Code, Compile, Run and Debug Pascal program online.
Write your code in this editor and press "Run" button to execute it.

https://www.onlinegdb.com/online_pascal_compiler

}


program Hello;
var
   //Part A    
   //time: array of Integer = (7, 15, 30);
   //distance: array of Integer = (9, 40, 200);
    

   // Part B
   time: array of LongInt = (71530);
   distance: array of LongInt = (940200);

   ways: LongInt = 1;
   w: LongInt = 0;
   i: LongInt;
   j: LongInt;
   d: LongInt = 0;

begin
   
   for j := 0  to Length(time) - 1 do
   begin
        w := 0;
        for i := 0  to time[j] - 1 do
            begin
            d := i * (time[j] - i);
            if (d > distance[j]) then
                w := w + 1
            
        end;
        ways := ways * w;
   
   end;
   
   writeln('Answer: ', ways);
   
end.

