from django.shortcuts import render, redirect
from django.http import HttpResponse
from django.contrib import messages
import requests, random
import json
from urllib.request import urlopen

# Create your views here.

def index(request):
    return render(request, 'entertainment/index.html')

def trivia(request):
    #currently i'm only pulling one question set from the api, will need to add a larger pull and the ability to post these questions sequentially in the html.
    response = requests.get('https://opentdb.com/api.php?amount=1')
    rawdata = json.loads(response.text)
    triviadata = (rawdata.get('results'))
    list1 = triviadata[0]
    q1 = [list1.get('question')]
    a1 = list1.get('incorrect_answers')
    c1 = [list1.get('correct_answer')]
    a1.extend(c1)
    q1 = str(q1)[2:-2]
    c1 = str(c1)[2:-2]
    random.shuffle(a1)
    if request.method == 'POST':
        testAnswer(request)
    context = {'questions': q1, 'answers': a1, 'correct': c1}
    return render (request, 'entertainment/trivia.html', context)

def testAnswer(request):
    selAnswer = request.POST.get('answer')
    selCorrect = request.POST.get('correct')
    print(selAnswer)
    print(selCorrect)
    if selAnswer == selCorrect:
        messages.success(request, 'Your answer is CORRECT!')
    else:
        messages.warning(request, 'Your answer is incorrect.')
        
    return redirect('/entertainment/trivia')
