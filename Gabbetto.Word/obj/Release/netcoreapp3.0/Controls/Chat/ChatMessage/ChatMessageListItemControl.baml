   M S B A M L   `   `   `  ���� G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core -    'Fasseto.Word.ChatMessageListItemControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Fasseto.Word     Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core     .����   �� Padding$  5q�
������ ._�� .+��� $	��Top=�$
��Left=�$��0 7.5 0 7.5q�$��35��
��� � �   ForegroundLightBrush#��[  $��1q�y��� *
SentByMe+ �� 	Converter /   )Fasseto.Word.BooleanToVisibilityConverter   �� CornerRadius �� *ActualWidth+ �� RelativeSource �� *Self+���� *ActualWidth+ �� *Self+._��� $��Center=�$��Center=�#��[    LatoRegular#��[ ���� *
Initials+� $��	25 0 25 0q����� *
SentByMe+ /   )Fasseto.Word.SentByMeToAlignmentConverter   � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .����  �� 
TargetName$ TimeDetails�� �� TargetProperty$ Opacity�.��W� 	 W� To 1	 g� Duration$	 
00:00:00.5D�:� $ 
MouseLeave��.[��� .���� $ TimeDetails��$ Opacity�.��W�  0$	 
00:00:00.5D�
 � RowDefinitions
 �� $
��Auto ��� $
��Auto �.+�� $��0��
 �� $
��Auto ��� $
��Auto �.+��� $	��Top=����� *
SentByMe+   y��� *HasImageAttachment+ 3   -Fasseto.Word.BooleanToVisibilityGoneConverter  ._���   SpinningText#��[ #��[   �� Padding$ 20q� � DataContext �� *ImageAttachment+y��� *ImageLoaded+    �� ConverterParameter$
 True���� $��0��$ 10��$��0 0 0 15q�._��� �   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.ClipFromBorderProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value$
 True��$	��500���   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.AnimateImageFadeInOnLoadProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value$
 True�� �� *ImageAttachment+���� *LocalFilePath+ �� NotifyOnTargetUpdated$
 True��� $��1������ *
SentByMe+   y��� *
HasMessage+   
 �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $ 10��$  15q�$��0������ *
SentByMe+ 0   *Fasseto.Word.SentByMeToBackgroundConverter  ._��� $��Center=�$
��Wrap=�#��[   WordDarkBlueBrush#��[ ���� *	Message+F� $��1��
���   �$��
10 -1 10 0q� K� ZIndex$ 1��+����        р�� ��� � -1    �        	$��0������ *
SentByMe+   ���� *
SentByMe+   �� -   $��TimeDetails��$��2�� �� Orientation$ 
Horizontal=� J� Opacity$ 0Q����� *
SentByMe+   $
 True��.+��� #��[  $��
10 0 10 0 q�  FontSizeSmall#��[ #��[ ���� *MessageSentTime+ -   'Fasseto.Word.TimeToDisplayTimeConverter  �� #��[ #��[ #��[ ���� *MessageReadTime+ *   $Fasseto.Word.TimeToReadTimeConverter  