I began my two week sprint on The Space Bar project in the middle of its’ lifecycle.
SpaceBar is a fictional restaurant and bar in space that also provides other services including APIs and a wiki. The project uses Python with a Django framework, including JSON, HTML, CSS, and JavaScript. I was able to introduce new aspects to the project as well as improve the functionality of previous stories.

WEBSITE COLOR PALETTE SELECTION
The SpaceBar website was using a lot of different color schemes, selected a picture from the website and developed a color palette from it using the website coolors.co/app to help select a good color scheme.
Established a root in our css file for the colors.
Set the colors for our primary buttons.

SUNTRACKER APP DEPRECATION
The Suntracker app had been replaced with the my_Location app.
Removed all links and references to Suntracker.
Commented out mention of the app in the main urls file.
Double checked that all of the functionality from the Suntracker app made it into the my_Location app.
Removed the templates and folders referencing the now deprecated Suntracker app.

WHILE YOU WAIT TRIVIA APP
Tasked with using a trivia API to build an app for customers to distract themselves while they waited for their food order.
Introduced a new Entertainment section to the project.
Built a trivia app in this section.
The trivia app connected to the website opentdb.com/api_config.php for the data needed for the app.
Retrieved the data and formatted it in a way to display nicely on the webpage.
Used radio buttons for the answer choices and a submit button to see if the user selected the correct answer.
The app then reported to the customer as to whether they chose the correct answer and provided the next question.

REGISTRATION PROCESS
Improved our registration page.
Added to the current registration app the ability to log the user in and redirect them to the home page after a successful registration (previously after a user registered it took them to the login page).
Added logic to the registration form to check to see if the Password and Confirm Password were the same and if not when the form is submitted an alert pops up on the form to inform the user as to the problem (previously it just reloaded the registration form without letting the user know there was a problem).
