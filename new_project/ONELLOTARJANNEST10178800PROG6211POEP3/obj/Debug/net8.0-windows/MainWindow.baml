   M S B A M L   `   `   `  ����`  \ONELLOTARJANNEST10178800PROG6211POEP3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:ONELLOTARJANNEST10178800PROG6211POEP3%ONELLOTARJANNEST10178800PROG6211POEP3  5   	   6    0ONELLOTARJANNEST10178800PROG6211POEP3.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:ONELLOTARJANNEST10178800PROG6211POEP3     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � ���	#FF0F3BB0$��0,0,0,-6q�6"    � ColumnDefinitions 5
   
   �� 5      $��6* �6   �� 5      $
��764* �6   �� 5      $	��31* �6   �� 5      $��6* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $
��Left=�6   $��	172,0,0,0q�6/   $
��Wrap=�6B   $#��Welcome to the Recipe Library��6V   $��Center=�6{   $
��Bold"�6�   $��Times New Roman)�6�   $��18(�6�   $��51��6�   $	��207��6�   $��1��6�   �� 5   
   $��1��6   $��1��6%   $	��Top=�62   $��49,10,316,0q�6J   $	��361��6_    � 	Resources 5       �� 
TargetType �� Property �� Value��%T   '��       �� 5      " ��6   .�5      ��  � ��
 �����63   5      5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0,10,0,0q�62   .+�5      �� $��Recipe Name:��6   $	��100��60   $��Center=�6<   �� 5      -   5         ��Name$ RecipeNameTextBox��5      $	��200��65   $��30��6A   $��0,0,0,0q�6M   ���	#FF0207166^   5      �� 5       $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5!      �� $j��dEnter ingredients with quantities,name,unit, calories and Food Group(e.g.,'20,kg,flour, 250,Grains')��6   $��99��5"      $��Center=�5#      $
��Wrap=�5$      $	��123��6)   �� 5%      -   5        $ IngredientNameTextBox��5%      $	��200��69   $	��100��6E   	 �� TextWrapping$
	 Wrap=�6R   
 �� AcceptsReturn$

 True��6f   ���	#FF0207166{   �� 5'      $��28��6   $��65��6'   5)      �� 5*      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5+      �� $'��!Enter all the steps to the Recipe��6   $	��100��5,      $��Center=�5-      $
��Wrap=�5.      �� 5/      -   5        $ StepsTextBox��5/      $	��200��60   $	��100��6<   $��0,0,0,0q�6I   $
	 Wrap=�6Z   $

 True��6n   ���	#FF0207166�   50      �� 51      $ 
Horizontal=�6   $��	60,20,0,0q�62   .+�52      �� -   5         ��Name$ SaveRecipeButton��52      $��Save Recipe��63   $��51��6I   $	��175��6U   ���	#FFDACECE��53      �� 54       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��55      �  � Color$ Black��6+   � 56      $ 	#FF0827C3��6+    � Offset$ 1Q�6=   57      59      5:      5;      5<      5>      