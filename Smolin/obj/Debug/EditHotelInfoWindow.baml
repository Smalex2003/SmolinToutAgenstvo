   M S B A M L   `   `   `  ����A  =Smolin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SmolinSmolin  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	        Smolin.EditHotelInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Smolin     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$#  Изменение отеля��5	   	   $	��400��6!   $	��450��6.   $	��250��6:   $	��300��5
      ���#bae3e8 � 	Resources 5         
NullImage3��%r   &	        ��5   
   PLC:\Users\Александр\source\repos\Smolin\Smolin\Resources\picture.png��5      5      .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%    � RowDefinitions 5      �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      $	��150 �6    6/   .+�5      �� $��0��6   $��0��6!   $"��Название отеля:��61   $��Center=�6K   $��Right=�6f   6�   �� 5      $��1��6   $��0��6!   $&�� Количество звезд:��61   $��Center=�6M   $��Right=�6h   6�   �� 5       $��2��6   $��0��6!   $#��Название страны��61   $��Right=�6K   $��Center=�6g   6�   �� 5!      -   5        $��TxtNameHotel��5!      $��0��6*   $��1��67   �� 5"      -   5        $��TxtCountStars��5"      $��1��6+   $��1��68   �� 5#      -   5         ��Name$ CmbNameCountry��5#   0    �� DisplayMemberPath$
 Name��6   $��2��6H   $��1��6U   6g   A� 5$       A� Rows$ 1��6    A� Columns$ 2��6#   $��3��6/   $��0��6<   $��2��6L   .+�5%      �� -   5         ��Name$ BtnDeleteHotel��5%      $��Удалить��61   
�������
�������6�   �� 5&      -   5        $ BtnUpadateHotelInfo��5&      $+��%Применить изменение��66   
�������
�������6�   5'      �� 5(      -   5        	 ��Name$	 ImgHotel��5(      $��0��6&   $��4��63   $��2��6D   $��Center=�6�   $��Center=�6�   ��6T   �� 
 �� FallbackValue#
 [  6�   �� 5)      -   5        $ Overview��5)      $'��!Добавить картинку��6'   $��2��6Z   $��3��6j   
�������
�������6�   �� 5*      $��4��6   $��3��6"   $��3q�66   
���   �._�5+      A� $ 1��6   $ 3��6'   .+�5,      �� -   5        $ PrevImg��5,      $	��←��6E   $��80(�6Q   $��Center=�6_   $��Center=�6|   
�������
�������6�   �� 5-      -	   5        $	 HotelImg��5-      ��6.   �� *ImageSource+6O   �� 5.      -
   5        $ NextImg��5.      $	��→��6E   $��80(�6Q   $��Center=�6_   $��Center=�6z   
�������
�������6�   5/      50      52      53      54      