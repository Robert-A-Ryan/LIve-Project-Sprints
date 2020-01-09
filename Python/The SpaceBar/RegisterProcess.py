def registerView(request):
    if request.method == "POST":
        form = UserCreationForm(request.POST)
        if form.is_valid():
            username = form.cleaned_data.get('username')
            password1 = form.cleaned_data.get('password1')
            password2 = form.cleaned_data.get('passowrd2')
            form.save()
            messages.success(request, 'Account created successfully.')
            user = authenticate(username=username, password=password1)#this authenticates the user and logs them in without having to go to the login page 11-14-19
            login(request, user)
            #changed to automatically log the user in and redirect to home 11-14-19 rr 
            return redirect('home')
        else:
            messages.warning(request, 'The Passwords Do Not Match', extra_tags='alert')
    else:
        form = UserCreationForm()
    return render(request, 'registration/register.html', {'form':form})
