
Automation and Test Experiment

January 25, 2014

This experiment explores unit testing and coded UI testing, integrated with the development of a library consumed by a user interface, in Visual Studio 2013 Premium. You can download the source from github at https://github.com/matthewkastor/AutomationAndTestExperiment/ To use this solution you'll need Visual Studio Ultimate or Premium as the other editions don't support Coded UI tests. You can currently download a trial version of either version if you'd like to do some experimenting. After opening the solution run BUILD -> Clean Solution, then BUILD -> Build Solution. Everything should compile without errors. If you have trouble, file an issue on the github repo and I'll try to fix it. https://github.com/matthewkastor/AutomationAndTestExperiment/issues

On a side note, Test Automation FX http://www.testautomationfx.com can do Coded UI testing and they offer a free version that integrates with any version of Visual Studio, even the express versions. Since Visual Studio includes the Unit Testing framework with all versions you'd just have to replace the Coded UI project with a TAFX project. I can't speak for the quality or the level of integration that TAFX has with development in Visual Studio, I'm just saying that if you can't afford a 6,000 + price tag for the version of VS with Coded UI support, you can find a few alternatives or try your luck hand rolling something using System.Windows.Automation (see UIAutomationClient, included in the .Net framework).
Solution Contents

    AutomationAndTestExperiment_PortableClassLib
    AutomationAndTestExperiment_UnitTestProject
    AutomationAndTestExperiment_UI
    AutomationAndTestExperiment_CodedUITestProject

Portable Class Library

The portable class library is where it all begins. I know I want to write some kind of program, and I have an idea of what I want this program to do. So, I fire up the Visual Studio and start a Portable Class Library project. I'm not even interested in the user interface at this point, all I want to do is create the logic that will do all the thinking for me. There's plenty of time to pretty it up once I get it working.

Now, I could just start banging out some code until I think it's doing what I want it to and, that's a great way to go for something as simple and small as this. The thing is, I don't want to think about a lot. I want to just write code and have some sort of verification to tell me when I've got it right. I should probably write a test that will call my methods and let me know if they're returning the results I expect. That way, I can bang out some code, test it, and when the tests pass I'll be confident that I've written something useful to me. Then I can take this first draft of my library and do optimizations and other fun stuff, knowing that if I break my code my tests will tell me.
Unit Test Project

Alright, so I've got an empty class library. This is the perfect time to start a unit test project and create a reference to the class library. After I've done that, I just have to decide what I'm going to call my methods and get my head around what they're going to do, exactly.

I've decided to create a class called MyStaticClass that will have a super complicated method called SayHi. SayHi will return the string "Hi" when it's called. Sure, I could bang it all out without tests but that wouldn't show me anything about the process. I don't want to be stumped later when I have actual work to do so I'm going to stub out the class method and write my test before I actually write the method body. With the method stubbed out I can utilize intellisense and make sure I don't misspell things. This is good stuff.

Now, the test isn't so complicated this time. This is where I'd spend some time figuring out all the different inputs and outputs I either wanted or didn't want, then write up some tests to make sure my method was well behaved. For this one though, all I really need to do is check whether SayHi returns a string that matches "Hi" and fail it if it does not. Good stuff. So my test method just calls SayHi and asserts that its return value will equal "Hi". Straightforward stuff.

At this point, the solution won't build because SayHi doesn't return the string that our stub promises it will. That's the compiler doing some linting to prevent obvious mistakes. Nice. Ok, so to get it to compile, implement SayHi as a return statement that returns an empty string. Now it's ready, the solution will compile, so do it. Then, open up the Test Explorer (Test -> Windows -> Test Explorer) and you should see your unit tests. Right click the test and run it. The test will fail because it expects SayHi to return "Hi" but saw that it actually returned an empty string. Neat huh? Fix SayHi and run the test again. My setup rebuilds the solution when tests are run. If your setup doesn't rebuild first then you'll have to do it yourself. At any rate once SayHi is doing what the test thinks it should be doing, you'll see a green checkmark instead of a red x. Everything will be awesome then, except there still won't be a badass user interface to show off this amazing library's functionality...
UI

So yeah, consoles are cool and all but... Add a Windows Forms project to the solution. This is about to get awesome. Add a reference from the Windows Forms project to the Class Library project. Shazam, it's like left brain and right brain, a place for creative art and a place for logical thought. Draw the pictures however you want, the end goal is to end up with a button that calls SayHi and updates a disabled textbox with the return value of SayHi. So yeah, there's no reason to write the logic of the form yet. Maybe one of your buddies will do that and you're just going to make it way, way, pretty. It's ok. There is a great way to let your buddy know what you want the form to do. Just add the controls to the form and decorate it to your hearts content, then create a Coded UI test so your buddy can tell when he's got it working nice for you. Cool huh? Alright, you've got a button and a text box setup just how you want them to look? Good.
Coded UI Test

Alright, this part is super easy. You basically record yourself clicking the button on the form and add an assertion that the textbox will have the value "Hi" in it afterward. Take a look at MyForm_CodedUITest.cs and search for Diagnostics.Process to see how I've launched the debug version of the UI on test setup, and closed it on test teardown. That makes things run smooth.

So, to record your actions you right click in the body of the empty test method and  Generate code for coded ui test -> Use coded ui test builder. Visual Studio will minimize and you'll see the CodedUITestBuilder running in the corner of your screen. There are a few self explanatory buttons that I'll take a second to explain. "record" records your keystrokes and mouse clicks. It tries to identify the controls you're messing with as accurately as possible so your screen doesn't have to be at the exact same resolution with the windows in the exact same spot when it plays the recording back. It's pretty smart stuff. "show recorded steps" will show you a list of the steps that have been recorded and allows you to delete them in case you've made mistakes and don't want to start over from the beginning. The bullseye looking thing is what you use to add / remove arbitrary controls to / from your map, make assertions about the state of controls, and get information. It's similar to inspector tools in the web browser and the finder in spy++. "generate code" is the magic button that allows you to create code to repeat your actions or make assertions. That's right, you can create entire tests without writing any code.

Now, the cool thing to do would be to setup the test setup and teardown methods. The coded ui test will be in the test explorer, and the test will pass (build, run tests). The reason it passes is because you haven't told it that anything went wrong. Change the test method so it throws an error. Do something like Assert that false is true and check out the awesome red x. Well that's kind of silly but it does say something important, tests pass by default... keep it in mind. Record yourself clicking the button and add an assertion about the text box's text being equal to whatever it actually is. You'll record the click, hit the generate code button, drag the bullseye over the text box, highlight the text property, add the assertion, generate code again, then close the CodedUITestBuilder. You'll see two new calls inside your test method. Awesome huh? Run the test. It should fire up the form, click the button, and make sure the text field is blank. If it does all that and passes then you're almost ready.

Open UIMap.uitest and find your assertion in the left hand pane. Right click it and chose the option to move it. This will copy the method and its properties over to UIMap.cs where you can edit it to your hearts content without worrying that it will be overwritten if you decide to re-record things. Besides, you need to edit it so it looks for the value "Hi" in the textbox. It's easy. After you've moved the assertion look in UIMap.cs for "Parameters to be passed into 'AssertMessageIsHi'" and change it so the Expected value is "Hi" instead of an empty string. Re-run the test and watch it fail. You could even go as far as editing the text field so it said "Hi" just to verify that the test will pass, be sure to change it back if you do though.
Wrapping it all Up

Now, comes the fun part. Either you or your buddy can double click the button on the form and write a little logic into the generated click handler stub. Once the button changes the text field's value to "Hi" then all your tests should pass.

Wait, what? That doesn't say things are working right. What happens if I change the SayHi method to say "Hello". If the button just changes the box to say "Hi" and doesn't actually use the return value of SayHi then . . . Gah. Well, I suppose there's a better test to be made. Maybe the expected value of the assertion could be the returned value of the SayHi method. That would make sure the text field ended up equal to whatever was returned from SayHi... Hmmmm... yes, the Coded UI test is just testing the correctness of the UI and the Unit test can test the correctness of the library. . . Good stuff.

If you've followed all of that then you'll have a project similar to this one. If not, you can still see how separate tests for the UI and the logic will help sort out where bugs are. Change the SayHi method in the portable class lib here inside MyStaticClass, make it say something other than "Hi" and run the tests. You'll immediately know where the code is failing, either the test is bad or the method. And as you can see already, even a simple application like this requires enough code to make it take a couple minutes to look through it all. With good tests you can write massive libraries and and user interfaces but still be able to spot problems like you were working on something small. It's nice. Plus, as an added bonus, you can have libraries that depend on one another and you'll be able to tell when you break the dependant library as soon as you run the tests for it. As long as you've written your unit tests with enough granularity you should be able to spot what's changed about your dependency and either update your dependant or roll back your changes. Easy peasy.

Have all kinds of fun! Try not to swear, this stuff is all amazing. :D