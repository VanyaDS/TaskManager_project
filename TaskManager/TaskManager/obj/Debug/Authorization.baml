   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager  5   	       TaskManager.Authorization   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TaskManager     5   	     � Title$  Authorization��5   	   $��572.63��6   $��434.483��6/    � 
ResizeMode$ NoResize=�6@   
������� � WindowStartupLocation$ CenterScreen=�6k   ��5      �� 5   
   -   5        fon�� �� ImageSource$ fonReady.jpg��5   "   .��5      � $��
0,0,0,-2.4q�6    � ColumnDefinitions 5   
   �� 5      $	��43* �6   �� 5      $
��171* �6   .+�5   
   �� -   5         ��Name$	 aut��5      $��Authorization��6   $��1��65   $��
0,5,70.4,0q�6E   $	��Top=�6Y   $��60��6q   $��36(�6}   
�������$
��Bold"�6�   � 5   
   -   5         �Name$ logGrid��5      $
��Left=�6    $��
42,75,0,27q�6;   $	��344��6O   $��2��6[   ��5      �� 5      $ fonReady.jpg��6   .+�5!      �� 
���   �$��2q�6)   $
��Left=�6=   $	��426��6X   $	��Top=�6e   $	��344��6}   �� 5"      -   5         ��Name$ loginTB��5"      $��40��6'   $��
12,65,12,0q�63    �� TextWrapping$
 Wrap=�6G   $	��Top=�6\   $��14(�6t   $��Arial)�6�   G� 5$      -   5        	 G�Name$	 passTB��5$      $��12,161,12,0q�6*   $	��Top=�6?   $��40��6W   
�������6c   � 5&      
 � RowDefinitions
 5'      �� 5(      $
��242* �6$   �� 5)      $	��21* �6$    5+      �� 5,      �� 5-      $	��0.8 �6'   .+�5/      ��  �� Orientation$ Vertical=�6   $��2��64   $��327,0,0,-0.4q�6H   $��2��6^   �� 50      -   5        $��Log in��50      $
��Left=�6*   $��104,253,0,0q�6E   $	��Top=�6Z   $	��131��6r   $��45��6~   
�������6�   �� 51      -   5         ��Name$ regTextBlock��51      $��90,381,90.2,0q�62   $
��Wrap=�6I   $C��= If you don't have an account you can click here and register��6]   $	��Top=�6�   $��34��6�   $��2��6�   53      �� 54      -   5        $ loginLabel_Copy1��54      $��Enter login��62   $��120,30,120.2,287q�6H   
�������$��18(�6u   �� 55      -	   5        $ loginLabel_Copy2��55      $��Enter password��62   $��105,126,105.2,191q�6K   
�������$��18(�6y   56      57      5:      5;      