   M S B A M L   `   `   `  ����G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  5      L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core 5      -    'Fasseto.Word.ChatMessageListItemControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Fasseto.Word     5      Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core     5      .��5
      ��   �� Padding$  5q�6   
������ ._�5   
   � .+�5      �� $	��Top=�6   $
��Left=�5      $��0 7.5 0 7.5q�5      $��35��5      
��� � �   ForegroundLightBrush#��[  5      $��1q�5      y�5      �� *
SentByMe+ �� 	Converter /   )Fasseto.Word.BooleanToVisibilityConverter   �� CornerRadius 5      �� *ActualWidth+ �� RelativeSource �� *Self+��5      �� *ActualWidth+ �� *Self+._�5      �� $��Center=�5      $��Center=�5      #��[  5        LatoRegular#��[ 5      ��5      �� *
Initials+5      5      � 5"      $��	25 0 25 0q�6   ��5#      �� *
SentByMe+ /   )Fasseto.Word.SentByMeToAlignmentConverter   � Triggers 5%      :� 5'       :� RoutedEvent$ 
MouseEnter��6#   .[�5(      �� .��5)      ��  �� 
TargetName$ TimeDetails��6)    �� TargetProperty$ Opacity�6M   .��5*   "   W� 	 W� To 162   	 g� Duration$	 
00:00:00.5D�69   5+      5,      5-      :� 50      $ 
MouseLeave��6#   .[�51      �� .��52      �� $ TimeDetails��6)   $ Opacity�6M   .��53   "   W�  062   $	 
00:00:00.5D�69   54      55      56      
 � RowDefinitions
 59      �� 5:      $
��Auto �6$   �� 5;      $
��Auto �6$   .+�5?      � $��0��6   
 5A      �� 5B      $
��Auto �6(   �� 5C      $
��Auto �6(   .+�5H      �� $	��Top=�5I      ��5H      �� *
SentByMe+   y�5J      �� *HasImageAttachment+ 3   -Fasseto.Word.BooleanToVisibilityGoneConverter  ._�5L      ��   SpinningText#��[ 6$   #��[  5M        �� Padding$ 20q�5N        � DataContext 5O       �� *ImageAttachment+y�5P       �� *ImageLoaded+    �� ConverterParameter$
 True��5S      �� 5W      $��0��6   $ 10��5X      $��0 0 0 15q�5Y      ._�5[      �� �   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.ClipFromBorderProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value$
 True��5]       $	��500��5^       �   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.AnimateImageFadeInOnLoadProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value$
 True��5_        5[       �� *ImageAttachment+��5\       �� *LocalFilePath+ �� NotifyOnTargetUpdated$
 True��5_       5b      � 5e      $��1��6   ��5f      �� *
SentByMe+   y�5g      �� *
HasMessage+   
 5i      �� 5j      $
��Auto �6,   �� 5k      $
��Auto �6,   �� 5l      $
��Auto �6,   .+�5p      �� $ 10��6!   $  15q�5r   !   $��0��5s   !   ��5q   !   �� *
SentByMe+ 0   *Fasseto.Word.SentByMeToBackgroundConverter  ._�5v      �� $��Center=�6(   $
��Wrap=�5x   (   #��[ 5y   (     WordDarkBlueBrush#��[ 5z   (   ��5w   (   �� *	Message+5z   (   5|      F� 5      $��1��6   
���   �$��
10 -1 10 0q�5�       K� ZIndex$ 1��5�      +����        р�� ��� � -1    �        	$��0��5�      ��5�      �� *
SentByMe+   ��5�      �� *
SentByMe+   �� 5�      -   5        $��TimeDetails��5�   %   $��2��5�   %    �� Orientation$ 
Horizontal=�5�   %    J� Opacity$ 0Q�5�   %   ��5�   %   �� *
SentByMe+   $
 True��.+�5�      �� #��[  5�   (   $��
10 0 10 0 q�5�   (     FontSizeSmall#��[ 5�   (   #��[ 5�   (   ��5�   (   �� *MessageSentTime+ -   'Fasseto.Word.TimeToDisplayTimeConverter  5�   (   �� 5�      #��[ 5�   '   #��[ 5�   '   #��[ 5�   '   ��5�   '   �� *MessageReadTime+ *   $Fasseto.Word.TimeToReadTimeConverter  5�   '   5�      5�      5�      5�      5�      5�      5�      