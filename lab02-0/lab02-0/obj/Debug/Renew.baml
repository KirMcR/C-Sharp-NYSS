   M S B A M L   `   `   `  ����B  >lab02-0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:lab02_0lab02_0  5   	       lab02_0.Renew   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:lab02_0     5   	     � 
ResizeMode$  NoResize=�5       � Title$ Изменения��5   	   $	��450��6   $	��900��6(   .��5	      � 
���iii�.+�5
   
   � $��10,36,10.333,34.667q�6   
�������$��Center=�6?   $	��850��6\   $	��350��6h    � RowDefinitions 5      �� 5      $	��13* �6    �� 5      $	��67* �6    �� 5      $
��260* �6    �� 5      $	��10* �6     � ColumnDefinitions 5      �� 5      $	��27* �6#   �� 5      $	��48* �6#   �� 5      $
��775* �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5         AutoGenerateColumns .     HorizontalGridLinesBrush
 �����$   HorizontalScrollBarVisibility$ Disabled=�6j   "   VerticalScrollBarVisibility$ Visible=�6�   	   RowBackground
	 �����
   AlternatingRowBackground

 �����$��18(�5   H      
IsReadOnly . $	��850��6h   $��Center=�6t   $��3��6�   $��4��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Earlyer��,  &System.Windows.Controls.DataGridColumn   Header$ Было��5   R      Width5  /System.Windows.Controls.DataGridLengthConverter$	 425 6`      CanUserSort .     CanUserReorder .     CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Was+   ElementStyle 5      �� 5       �� 
TargetType" ��6$   .�5   "   ��  �� Property � �� �� Value$
 Wrap=�6A   6P   5      5        5       -   5        Present��$ 
Стало��5    :   $	 425 6c    .   .   .   6I   �� *New+ 5!      �� 5"      " ��6$   .�5#   "   ��  � ��$
 Wrap=�6A   6P   5$      5&      5(      5)      5*      5+      