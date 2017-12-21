using System;
using System.Collections.Generic;
using ICT13580048EndB.Model;
using Xamarin.Forms;

namespace ICT13580048EndB
{
	public partial class ProductNewPage : ContentPage
	{
		Product product;
		public ProductNewPage(Product product = null)
		{
			InitializeComponent();
			this.product = product;
			titleLable.Text = product == null ? "เพิ่มประวัติใหม่" : "แก้ไขรายชื่อ";

			saveButton.Clicked += SaveButton_Clicked;
			cancelButton.Clicked += CancelButton_Clicked;

            carbandPicker.Items.Add("รถยต์");
            carbandPicker.Items.Add("รถมอเตอร์ไซต์");

			brandPicker.Items.Add("Audi");
			brandPicker.Items.Add("ฮอนด้า");
			brandPicker.Items.Add("BMW");

			colorPicker.Items.Add("ขาว");
			colorPicker.Items.Add("ดำ");

			addressPicker.Items.Add("กรุงเทพ");
			addressPicker.Items.Add("เชียงใหม่");
			addressPicker.Items.Add("นครราชสีมา");
			addressPicker.Items.Add("นครปฐม");
			addressPicker.Items.Add("เพชรบุรี");


			yearStepper.ValueChanged += YearStepper_ValueChanged1;
			if (product != null)
			{
                carbandPicker.SelectedItem = product.Carband;
				brandPicker.SelectedItem = product.Brand;
                genarationEntry.Text = product.Genaration;
				mileEntry.Text = product.Mile;
				colorPicker.SelectedItem = product.Color;
				delarEntry.Text = product.Deler;
                descriptionEditor.Text = product.Description.ToString();
				priceEntry.Text = product.Price;
				addressPicker.SelectedItem = product.Address;
				telEntry.Text = product.Tel;


			}


		}

		void YearStepper_ValueChanged1(object sender, ValueChangedEventArgs e)
		{
			int value = (int)e.NewValue;
			yearLabel.Text = value.ToString();
		}



		async void SaveButton_Clicked(object sender, EventArgs e)
		{
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบัญทึกใช่หรือไม่", "ใช่", "ไม่ใช่");

			if (isOk)
			{
				if (product == null)
				{
					product = new Product();

                    product.Carband = carbandPicker.SelectedItem.ToString();
					product.Brand = brandPicker.SelectedItem.ToString();
                    product.Genaration = genarationEntry.Text;
					product.Mile = mileEntry.Text;
					product.Color = colorPicker.SelectedItem.ToString();
					product.Deler = delarEntry.Text;
                    product.Description = descriptionEditor.Text;
					product.Price = priceEntry.Text;
					product.Address = addressPicker.SelectedItem.ToString();
					product.Tel = telEntry.Text;


					var id = App.DbHelper.AddProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ" + id, "ตกลง");
				}



				else
				{
                    product.Carband = carbandPicker.SelectedItem.ToString();
					product.Brand = brandPicker.SelectedItem.ToString();
                    product.Genaration = genarationEntry.Text;
					product.Mile = mileEntry.Text;
					product.Color = colorPicker.SelectedItem.ToString();
					product.Deler = delarEntry.Text;
                    product.Description = descriptionEditor.Text;
					product.Price = priceEntry.Text;
					product.Address = addressPicker.SelectedItem.ToString();
					product.Tel = telEntry.Text;

					var id = App.DbHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้า" + id, "ตกลง");
				}
				await Navigation.PopModalAsync();
			}
		}

		void CancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}
	}
}
