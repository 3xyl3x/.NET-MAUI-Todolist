using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
namespace MauiApp13;

public partial class MainPage : ContentPage
{

	// Create a collection to store the tasks
	ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();

	public MainPage()
	{
		InitializeComponent();
		TaskListView.ItemsSource = tasks;
	}

	// Event handler for the "Add" button click
	private void OnAddTaskClicked(object sender, EventArgs e)
	{

		string taskName = TaskEntry.Text;
		if (!string.IsNullOrWhiteSpace(taskName))
		{
			// Add the task to the collection
			tasks.Add(new TaskItem { TaskName = taskName });
			TaskEntry.Text = string.Empty; // Clear the entry field
		}
	}

	// Event handler for the "Complete" button click
	private void OnCompleteTaskClicked(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		TaskItem task = (TaskItem)button.CommandParameter;

		// Remove the completed task from the collection
		tasks.Remove(task);
	}
}

// Define a simple TaskItem class to represent tasks
public class TaskItem
{
	public string TaskName { get; set; }
}