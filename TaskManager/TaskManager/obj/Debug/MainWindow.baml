   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager  5   	       TaskManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TaskManager     5   	   -   5          � Title$  
MainWindow��5   	   $��654.8��6   $��970.8��6+   ��5	      �� 5
   
   -   5        fon�� �� ImageSource$ fonReady.jpg��5
   "   .��5      � -   5         �Name$ MainGrid��5      $��-3,0,-3.2,-0.2q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ TaskGrid��5      $��16(�6&   $
��Bold"�64   $��15,36,15,15q�6F      AutoGenerateColumns .     Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6)      Header 5      �� 5      $
��Date��6$   $��15(�60   
�������6?      CellTemplate 5      �� 5      .R�5      (  "System.Windows.Controls.DatePicker  $��0q�6P   	   SelectedDate	 6)   �� *CompleateDate+6P   5      5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5       $ 80 6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   ��  �� Path$ IsDone� 5"      �� 5#      $
��Done��6$   $��15(�60   
�������6?   5&      0  *System.Windows.Controls.DataGridTextColumn  5*      $	 300 6%   
 62   �� $ TaskText� 5,      �� 5-      $
��Task��6$   $��15(�60   
�������6?   5/        51      $ 90 6%   
 60   �� $ Priority� 52      �� 53      $��Priority��6$   $��15(�64   
�������6C   55        59      $	 100 6%   
 61   �� $ Category� 5:      �� 5;      $��Category��6$   $��15(�64   
�������6C   5=        5@      $ * 6%    5A      �� 5B      $��	Time left��6$   $��15(�65   
�������6D   5D      5H      5L      5M      