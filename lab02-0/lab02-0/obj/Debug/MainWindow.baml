   M S B A M L   `   `   `  ����B  >lab02-0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:lab02_0lab02_0  5   	       lab02_0.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:lab02_0     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ Парсер данных��5   	   $	��550��6   $	��900��6,    � 
ResizeMode$ NoResize=�68   .��5	      � 
���iii�.+�5
   
   �� -   5        $��Manage��5
   .    �� Orientation$ 
Horizontal=�6   $��255,462,219.667,6q�5      $��Center=�5      $y�Hidden=�66   .+�5      �� -   5         ��Name$ 	Backwards��5      $��4q�5      $��<��5      $��6q�5      $��30��6$   5   3   � 5      $��6q�6   $��Center=�5      $��Center=�5      .+�5      �� -   5         ��Name$ PageInfo��5      $�� ��6*   
���   �5      5      �� 5      -   5        $ Forward��5      $��4q�5      $��>��5      $��6q�5      $��30��6$   5   2   5       � 5"   
   $��158,28,35,59q�6   
�������$��Center=�6=   $	��701��6Z    � RowDefinitions 5#      �� 5$      $
��373* �6    �� 5%      $	��30* �6    .+�5'      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5'         AutoGenerateColumns .  $��10q�6E   	   HorizontalGridLinesBrush
	 �����$
   HorizontalScrollBarVisibility$
 Disabled=�6r   
�������   RowBackground
 �����   AlternatingRowBackground
 �����$��18(�5(   H      
IsReadOnly .    Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      -   5        Id��,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�5*   5      Header$) #Идентификатор УБИ: ��6I      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6�      CanUserSort .     CanUserReorder .     CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6f   �� *
FormatId+6�     5+      -   5        Name��$ Hidden=�5+   7   $ Наименование��6K   $	 665 6z    .   .   .   6a   �� *Name+   ElementStyle 5,      �� 5-       �� 
TargetType" ��6$   .�5.   "   ��  �� Property � �� �� Value$
 Wrap=�6A   6P   5/      51      53      54      � 55   
   $��0,0,25,6q�6   $��Center=�6!   $��Bottom=�6>   $��50��6Y   $	��869��6e   .+�56      �� -   5        $ Refresh_Button��56      $��Обновить��6-   $	��119��6Q   $
��Left=�6]   {�.  $��21,-281,0,214q�6�   �� 57      -	   5        $ GoBack_Button��57      $$��Вернуться к базе��6,   $	��119��6U   $
��Left=�6a   $��23,-119,0,52q�6|   $y�Hidden=�6�   �� 58      -
   5        $ Load_Button��58      $��Загрузить��6*   $��Right=�6K   $	��121��6g   {�. $��0,-440,727,373q�6�   59      5:      5;      