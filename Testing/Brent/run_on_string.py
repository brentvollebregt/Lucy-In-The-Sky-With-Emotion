print ("Getting Values...")
f = open("SentiWords_1.0.txt")
values_per_word = {}
for line in f:
    if line.startswith("#"):
        continue
    # Find a way to deal with dupes or find out if words aer a,n,v and then we can take the individual values
    # Will need to find a natual langage toolkit to do this thoguh
    # if line.split("#")[0] in values_per_word:
    #     print ("Already in", line.split("#")[0])

    values_per_word[line.split("#")[0]] = float(line.split("\t")[1].replace("\n", ""))


print ("Values Stored")

#input_string = input("Input: ")
input_string = """

Ladies and gentlemen
This is Mambo No. 5!

One, two, three, four, five
Everybody in the car, so come on let's ride
To the liquor store around the corner
The boys say they want some gin and juice
But I really don't wanna
Beer bust, like I had last week
I must stay deep, 'cause talk is cheap
I like Angela, Pamela, Sandra and Rita
And as I continue you know they're getting sweeter
So what can I do? I really beg you, my Lord
To me flirting is just like a sport
Anything fly, it's all good let me dump it
Please set in the trumpet

A little bit of Monica in my life
A little bit of Erica by my side
A little bit of Rita is all I need
A little bit of Tina is what I see
A little bit of Sandra in the sun
A little bit of Mary all night long
A little bit of Jessica here I am
A little bit of you makes me your man

Mambo No. 5!

Jump up and down and move it all around
Shake your head to the sound
Put your hands on the ground
Take one step left and one step right
One to the front and one to the side
Clap your hands once and clap your hands twice
And if it looks like this then you're doing it right

A little bit of Monica in my life
A little bit of Erica by my side
A little bit of Rita is all I need
A little bit of Tina is what I see
A little bit of Sandra in the sun
A little bit of Mary all night long
A little bit of Jessica here I am
A little bit of you makes me your man

Trumpet!
The trumpet!
Mambo No. 5!
(Ha ha ha)

A little bit of Monica in my life
A little bit of Erica by my side
A little bit of Rita is all I need
A little bit of Tina is what I see
A little bit of Sandra in the sun
A little bit of Mary all night long
A little bit of Jessica here I am
A little bit of you makes me your man

I do ought to
Fall in love with a girl like you
Cause you can't run, you can't hide
You and me gonna touch the sky

Mambo No. 5!

"""

for ch in ['!', '"', '#', '$', '%', '&', "'", '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '', ']', '^', '_', '`', '{', '|', '}', '~', '\n', '\t']:
    if ch in input_string:
        input_string.replace(ch, "")

tokens = input_string.split(" ")
total = 0
average = []
for token in tokens:
    if token in values_per_word:
        total += values_per_word[token]
        average.append(values_per_word[token])
        print (token, "\t", values_per_word[token])

print ("Total: ", round(total, 3))
print ("Average: ", round(sum(average) / len(average), 3))
print ("Word Count: ", len(tokens))
print (round(total, 3), "\t", round(sum(average) / len(average), 3), "\t", len(tokens))
