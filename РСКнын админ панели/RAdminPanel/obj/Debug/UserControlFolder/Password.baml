   M S B A M L   `   `   `  ����F  BRAdminPanel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RAdminPanel.UserControlFolderRAdminPanel.UserControlFolder  5   	   ,    &RAdminPanel.UserControlFolder.Password   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:RAdminPanel.UserControlFolder     5   	   -   5          �Name$	  Win��5       � Title$ Window1��6	   $	��190��6&   $	��600��63    � WindowStartupLocation$ CenterScreen=�6?    � AllowsTransparency .  � WindowStyle$
 None=�6    � 
ResizeMode$ NoResize=�6�    � Icon$. (../Image/Img/Без названия.png��6�   ��6�   Z� .��5	      �  J� Effect 5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$	 265Q�6   	   Opacity$		 0.5Q�6/   
   ShadowDepth$
 0Q�6=      
BlurRadius$ 10Q�6M   .+�5   
   � $��10q�6   
������� 5   
     5      $	 265Q�6   $		 0.5Q�6/   $
 0Q�6=   $ 10Q�6M   .+�5   
   �  � RowDefinitions 5      �� 5      $��15 �6    6.   �� 5      6"   .+�5      �� ���#0A6E9E5      �� 5      $��1��6   .+�5      �� -   5         ��Name$ 
LogTextBox��5      $��14(�6.      styleLog#���   6=   
 � Tag$  Login��6`   $��24��6m   $	��340��6y   $��Right=�6�    �� Left$	 131��6�   
 �� Top$ 32��6�   G� 5      -   5         G�Name$ PassTextBox��5      $��14(�63   $ 	 Password��6C   $��24��6S   $	��340��6_   $��Right=�6k   $	 131��6�   $ 65��6�   �� 5      -   5         ��Name$ button_2��5       � Cursor$
 Hand��6B   $��
Выход��6P   $��25��6a   $	��155��6m   
�������$��2q�6�   ���#0A6E9E$	 139��6�   $ 99��6�   ��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value �#0A6E9E6;   5       � 	Resources 5!      ��%d   '��       �� 5"      " ��6    .�5#      ��  �@��CornerRadius$ 5,0,0,5��6=   5$      5%      5&      �� 5'      -   5        $ button_1��5'   6   $
 Hand��6   $��Вход��6'   $��25��6`   $	��164��6l   ���#0A6E9E
�������$��0q�6�   $	 294��6�   $ 99��6�    5(      ��%d   '��       �� 5)      " ��6    .�5*      ��  �@��CornerRadius$ 0,5,5,0��6=   5+      5,      5-      �� 5.      -   5        $!��Изменит пароль��5.      $	 349��62   $	 129��6D   ���	#FF0A6E9E$��13(�6l   6z   �� 5/      -   5        $ NewPass��5/        textbox_style#���  6+   $"  Введите пароль��6S   $��24��6i   $	��340��6u   $	 131��6�   $	 190��6�   �� 50      -   5        $ OldPass��50      #���  6+   $&   Повторите пароль��6S   $��24��6k   $	��340��6w   $	 131��6�   $	 251��6�   �� 51      $!��Введите пароль��6   $	 131��62   $	 166��6D   ���	#FF0A6E9E$��15(�6l   �� 52      $%��Повторите пароль��6   $	 131��64   $	 226��6F   ���	#FF0A6E9E$��15(�6n   �� 53      -	   5        $ button_1_Copy��53   6   $
 Hand��6   $��Вход��6'   $��25��6j   $	��164��6v   ���#0A6E9E
�������$��0q�6�   $	 294��6�   $	 286��6�    54      ��%d   '��       �� 55      " ��6    .�56      ��  �@��CornerRadius$ 0,5,5,0��6=   57      58      59      5:      5;      5<      5>      5?      