   M S B A M L   `   `   `  ����P  Lexamen-septembre-2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:examen_septembre_2022examen_septembre_2022  5   	   &     examen_septembre_2022.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:examen_septembre_2022     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         listboxProductsTemplate �� Orientation  listboxOrdersTemplate��%�  &	        &	 �     �� 5
   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��5 0 0 0q�6   ��6-   �� *	ProductID+�� 5      $��5 0 0 0q�6   ��6-   �� *ProductName+5      5      �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��5 0 0 0q�6   ��6-   �� *OrderProductID+�� 5      $��5 0 0 0q�6   ��6-   �� *OrderProductTotalSales+5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ listBoxProducts��5      $	��150��6+   $	��275��68   $
��Left=�6D   $��15 0 0 0q�6_   #��[  6�   ��6q   �� *ListProducts+ �� SelectedItem 6�   �� *SelectedProduct+5       �� 5"   
   -   5        $ listBoxOrders��5"      $	��150��6)   $	��275��66   $��Right=�6B   $��0 0 15 0q�6^   #��[ 6�   ��6p   �� *
ListOrders+5$      �� 5&   
   $��35 0 0 0q�6   $��1��6'   $	��325��64   $
��Left=�6@    � DataContext 6[   �� *SelectedItem+ �� ElementName$ listBoxProducts��.+�5'      �� $ 
Horizontal=�6   $	��325��62   .+�5(      �� $	��150��6   $��	ProductID��6$   �� 5)      $	��175��6   $��20��6&   
������� �� 
IsReadOnly$
 True��6d   ��62   �� *	ProductID+6d   5*      �� 5+      $ 
Horizontal=�6   $	��325��63   .+�5,      �� $	��150��6   $��ProductName��6%   �� 5-      $	��175��6   $��20��6&   ��62   �� *ProductName+5.      �� 5/      $ 
Horizontal=�6   $	��325��63   .+�50      �� $	��150��6   $��SupplierContactName��6$   �� 51      $	��175��6   $��20��6&   
�������$
 True��6n   ��62   �� *SupplierContactName+6n   52      �� 53      $ 
Horizontal=�6   $	��325��63   .+�54      �� $	��150��6   $��QuantityPerUnit��6$   �� 55      $	��175��6   $��20��6&   ��62   �� *QuantityPerUnit+56      59      �� 5;   
   $��1��6   $��Bottom=�6   $��Center=�69   $	��150��6V   $��
15 0 0 15 q�6b   $	��Maj��6v   
�����w���6�   �� *SaveProduct+5=      5>      