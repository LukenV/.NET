   M S B A M L   `   `   `  ����V  RSemaine 8 - WPF - TopPlaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Semaine_8___WPF___TopPlacesSemaine_8___WPF___TopPlaces  5   	   ,    &Semaine_8___WPF___TopPlaces.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Semaine_8___WPF___TopPlaces     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         ItemTemplate �� Orientation  
TitreStyle �� Property �� Value  
LabelStyle��%  &	        &	 -    &	 �    �� 5
   
   .R�5      �� $ 
Horizontal=�6   $��0 5 0 5q�62   .+�5      �� $��50��6   $��50��6#   $
��Fill=�6/   $��Center=�6W   $��Center=�6r   ��6>   �� *Image+6r   �� 5      $��Center=�68   $��Center=�6S   ��6   �� *Description+6S   5      5      �� 5   
   .�5      ��  � ��$ 18(�6/   �� 5       � ��
 �   �62   �� 5       � ��$ 2q�66   5      �� 5   
   .�5      ��  � ��$ Courier New)�61   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��250 �6   �� 5      $
��200* �6    � ColumnDefinitions 5   
   �� 5      $
��150* �6   �� 5       $
��650* �6   .+�5"   
   �� -   5         ��Name$ listBoxPhotos��5"   P   #��[  6   $��2��6?   $��0,0,8,0q�6g   $	��434��6x   $	��Top=�6�   ��6�   �� 5#      �� 5$   
   $��1��6   $
��Left=�6    $	��Top=�6;   $��
Top places��6S   #��[ 6h   $��
135,10,0,0q�6�   �� 5%   
   -   5         ��Name$ currentImage��5%      $��1��6&   $
��Left=�66   $��/photos/amsterdam.jpg��6Q   $
��Fill=�6p   $��
48,54,0,10q�6   $	��311��6�   �� 5&   
   $��1��6   $��1��6    $
��Left=�6-   $	��Top=�6H   $��nb votes��6`   #��[ 6s   $��	18,65,0,0q�6�   �� 5'   
   $��1��6   $��1��6    $
��Left=�6-   $	��Top=�6H   $��URI fichier��6`   #��[ 6v   $��	18,37,0,0q�6�   �� 5(   
   $��1��6   $��1��6    $
��Left=�6-   $	��Top=�6H   $��Description��6`   #��[ 6v   $��	18,10,0,0q�6�   �� 5*   
   -   5        	 ��Name$	 description_value��5*      $��1��6+   $��1��6;   $
��Left=�6H   $	��Top=�6c   $��	112,8,0,0q�6{   $��26��6�   $	��247��6�   ��6�   �� 
 �� ElementName$
 listBoxPhotos�� �� Path$ SelectedItem.Description��� 5+   
   -   5        $	 	uri_value��5+      $��1��6#   $��1��63   $
��Left=�6@   $	��Top=�6[   $��
112,35,0,0q�6s   $��26��6�   $	��247��6�   ��6�   �� $
 listBoxPhotos��$ SelectedItem.Uri��� 5,   
   -   5        $	 votes_value��5,      $��1��6%   $��1��65   $
��Left=�6B   $	��Top=�6]   $��
112,65,0,0q�6u   $��24��6�   $	��247��6�   ��6�   �� $
 listBoxPhotos��$ SelectedItem.NbVotes��� 5.   
   -   5        $��	18,60,0,0q�5.      $��1��69   $
��Left=�6I   $��1��6d   $	��160��6q   $��40��6}   .��5/      �� $ 
Horizontal=�6   $	��150��62   .+�50      �� $��
/jaime.png��6   $��25��6,   $��50��68   �� 51      $��Je vote pour��6   $��Center=�60   $��70��6K   $��	20,0,20,0q�6V   52      53      55      56      