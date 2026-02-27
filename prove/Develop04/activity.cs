using System;
using System.Media;      // <-- Added for SoundPlayer
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    private SoundPlayer _player;  // <-- Replace Process with SoundPlayer

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _player = new SoundPlayer("music.wav");  // <-- Load your WAV file here
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");

        try
        {
            _player.PlayLooping();   // <-- Play WAV in background looping
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to play music: {ex.Message}");
        }

        DisplaySpinner(3);

        Execute();

        Console.WriteLine($"\nGreat job! You have completed the {_name} activity.");
        Console.WriteLine($"Duration: {_duration} seconds");
        DisplaySpinner(3);

        StopMusic();  // Stop playing music when activity ends
    }

    protected abstract void Execute();

    protected void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("|");
            Thread.Sleep(300);
            Console.Write("\b \b/");
            Thread.Sleep(300);
            Console.Write("\b \b-");
            Thread.Sleep(300);
            Console.Write("\b \b\\");
            Thread.Sleep(300);
            Console.Write("\b \b");
        }
    }

    protected void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    private void StopMusic()
    {
        try
        {
            _player.Stop();  // <-- Stop the music playback
        }
        catch (Exception)
        {
            Console.WriteLine("Music already stopped or failed to stop.");
        }
    }
}
