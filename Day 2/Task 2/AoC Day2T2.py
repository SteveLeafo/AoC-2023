import re

file = open('AoCinput.txt', 'r')
txtfile = file.readlines()
redgamei = []
greengamei = []
bluegamei = []

score = 0

for i in range(len(txtfile)):
    split = txtfile[i].split(':')
    ccount = split[1]
    game = ccount.split(';')
    for j in range(len(game)):
        dispen = game[j]
        colour = dispen.split(',')
        for k in range(len(colour)):
            justcolour = re.sub(r'[^a-zA-Z]', '', colour[k])
            colournumber = re.sub("[^0-9]", "", colour[k])
                    
            if justcolour == 'red':
                redgamei.append(int(colournumber))
                
            if justcolour == 'green':
                greengamei.append(int(colournumber))
                
            if justcolour == 'blue':
                bluegamei.append(int(colournumber))
                
    redmax = max(redgamei)
    greenmax = max(greengamei)
    bluemax = max(bluegamei)

    score = score + (redmax * greenmax * bluemax)
    
    redgamei = []
    greengamei = []
    bluegamei = []

print(score)

