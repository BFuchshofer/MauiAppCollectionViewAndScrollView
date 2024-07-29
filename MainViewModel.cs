using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiAppCollectionViewAndScrollView;

[ObservableObject]
public partial class MainViewModel
{
	[ObservableProperty]
	private ObservableCollection<Item> data;

	[ObservableProperty]
	private bool isBusy;

	public MainViewModel() {
		data = [];
	}

	[RelayCommand]
	private async Task LoadData() {
		IsBusy = true;
		for (var i = 0; i < 50; i++) {
			Data.Add(new Item {
				Value1 = i.ToString(),
				Value2 = i.ToString(),
				Value3 = i.ToString(),
			});
			await Task.Delay(50);
		}
		
		IsBusy = false;
		OnPropertyChanged(nameof(Data));
	}
}

public class Item
{
	public string Value1 { get; set; }
	public string Value2 { get; set; }
	public string Value3 { get; set; }
}
