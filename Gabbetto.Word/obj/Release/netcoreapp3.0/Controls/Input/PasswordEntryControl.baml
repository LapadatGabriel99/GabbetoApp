   M S B A M L   `   `   `  ���� G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core '    !Fasseto.Word.PasswordEntryControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Fasseto.Word     Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core     .����    ForegroundDarkBrush#��[  $��	0 0 0 0.5q�._��   ForegroundLightBrush#��[   J� InputBindings  d�  d� MouseAction$ LeftDoubleClicke� �� Command �� *EditCommand+ � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .��W� 	 W� To 1 g� Duration$ 0:0:0.5D� �� 
TargetName$ 
EditButton�� �� TargetProperty$ Opacity�:� $ 
MouseLeave��.[��� .���� .��W�  0$ 0:0:0.5D�$ 
EditButton��$ Opacity�	 � ColumnDefinitions	 �� -   
 �Name$
 LabelColumnDefinition��$
��Auto ��� $��* ��� $
��Auto � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��Label��$��0��$
��Left=�$��15 12q�$��Center=�  LatoRegular#��[ ���� *Label+G� -    G�Name$ CurrentPassword��$��1��$��0�� J� Opacity$ 0Q�  FontSizeRegular#��[ #��[ $��2q�$��
10 10 15 8q�
 � Tag �� *CurrentPasswordHintText+�   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.FocusProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value �� *	Editing+�   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.SelectProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value �� *	Editing+�   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.AnimateFadeInProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value �� *	Editing+G� -   $ NewPassword��$��1��$��1��$ 0Q�#��[ #��[ $��2q�$��
10 10 15 8q� �� *NewPasswordHintText+ �� *	Editing+G� -   $ ConfirmPassword��$��1��$��2��$ 0Q�#��[ #��[ $��2q�$��
10 10 15 8q� �� *ConfirmPasswordHintText+ �� *	Editing+�� $��1��$
��15 8q�$��Center=����� *FakePassword+ �� *	Editing+ �� 	Converter )   #Fasseto.Word.BooleanInvertConverter  � $��2�� �� *	Editing+   .+��� -   $��
EditButton�� % !FontAwesomeEllipsisHorizontalIcon#��[   FontAwesome#��[ $ 0Q�$	��8 5q�$��0q� � Cursor$
 Hand��  FontSizeSmall#��[ $��Center=�#��[  ���� *EditCommand+�� $��2�� �� Orientation$ 
Horizontal=�.+���   FontAwesomeTickIcon#��[ #��[  �� 	IsDefault$
 True��$	��8 5q�$��0 0 5 0q�$
 Hand��$��Center=�  WordGreenBrush#��[ #��[  �� *	Editing+���� *SaveCommand+��  	 FontAwesomeCloseIcon#��[	 #��[  �� IsCancel$
 True��$	��8 5q�$��0q�$
 Hand��$��Center=� 
 WordOrangeBrush#��[
 #��[  �� *	Editing+���� *CancelCommand+