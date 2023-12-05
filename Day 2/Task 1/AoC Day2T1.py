import re

file = open('AoCinput.txt', 'r')
txtfile = file.readlines()

score = 0
redcount = int(12)
greencount = int(13)
bluecount = int(14)


for i in range(len(txtfile)):
    split = txtfile[i].split(':')
    ccount = split[1]
    game = ccount.split(';')
    for j in range(len(game)):
        dispen = game[j]
        colour = dispen.split(',')
        for k in range(len(colour)):
            greencheck = True
            bluecheck = True
            redcheck = True
            justcolour = re.sub(r'[^a-zA-Z]', '', colour[k])
            colournumber = re.sub("[^0-9]", "", colour[k])
                    
            if int(colournumber) > bluecount and justcolour == 'blue':
                bluecheck = False
                break                    
                    
            if int(colournumber) > greencount and justcolour == 'green':
                greencheck = False
                break

            if int(colournumber) > redcount and justcolour == 'red':
                redcheck = False
                break
                      
        if bluecheck == False or greencheck == False or redcheck == False:
            break
        
    
    if bluecheck == True and greencheck == True and redcheck == True:
        score = score + int(i+1)


    
print(score)
