   M S B A M L   `   `   `  ����G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  5      L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core 5          Fasseto.Word.ChatPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Fasseto.Word     5      Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core     5      -   5           Fasseto.Word.BasePage`1   Name$
  Page��5      $	��400��5	      $	��400��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5       $
��Auto �6   .+�5$   
   �� 
������ $��2��5%       K� ZIndex$ 1��5&      y�5'      �� *AnyPopupMenuVisible+ �� 	Converter /   )Fasseto.Word.BooleanToVisibilityConverter   �� ConverterParameter$
 True�� J� InputBindings 5)      d� 5*       d� MouseAction$ 	LeftClicke�6    �� Command 67   �� *PopupClickAwayCommand+5,      � 5/   
   $��50��6    � ColumnDefinitions 50      �� 51      $��* �6#   �� 52      $
��Auto �6#   .+�57      ��    ForegroundLightBrush#��[  58        FontSizeXLarge#��[ 59      $��Center=�5:      $��Center=�5;      $��2��5<      ��57      �� *DisplayTitle+5<      �� 5?      $��1��6   	 �� Orientation$	 
Horizontal=�6)   .+�5B      ��   ChatPageIconGrowButton#��[ 6     FontAwesomeSearchIcon#��[ 5C      ��5D      �� *OpenSearchCommand+�� 5G      #��[ 6    # FontAwesomeEllipsisVerticalIcon#��[ 5H      5I      � 5L      $��2��6   �   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.AnimateSlideInFromRightMarginProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]
   Value
 5M      �� *SearchIsOpen+ 5O      �� 5P      $
��Auto �6'   �� 5Q      $��* �6'   .+�5U      �� -   5        #��[ 5U        FontAwesomeCloseIcon#��[ 5V      #��[  5X      ��5W      �� *CloseSearchCommand+5[      �� 5^      $��1��6   
 � Tag$ Search text...��5_      $��0 5 5 5q�5`        FontSizeRegular#��[ 5b      ��5a      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=��   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.FocusProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value 5c      �� *SearchIsOpen+.��5d       5f      �� 5h      
 �� Key$ Return��6G    6%   �� *SearchCommand+6G   �� 5k      $	 Esc��6L    6%   �� *ClearSearchCommand+6L   .��5l   -   5n      5p      5r      )   #Fasseto.Word.ChatMessageListControl  5u   
   -   5          Name$ ChatMessageList��5u   '   $��1��6@    � DataContext 6M   �� �� 5w   
   $��1��6   $��Bottom=�5x      $
��Left=�5y      $ 2��5z      �   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.AnimateSlideInFromBottomProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value 5{      �� *AttachementMenuVisible+._�5}          Fasseto.Word.BubbleContent   6"   �� *AttachementMenu+5~      � 5�   
   $��2��6   $ 3��5�      $��50��5�      $	��114��5�      #��[  5�       5�      �� 5�      $
��Auto �6#   �� 5�      $��* �6#   �� 5�      $
��Auto �6#   .+�5�      �� #��[ 6     FontAwesomePaperClipIcon#��[ 5�        ForegroundDarkBrush#��[ 5�      $	��Top=�5�      ��5�      �� *	MinHeight+ �� RelativeSource ��  �� AncestorType Grid��5�      �� *AttachmentButtonCommand+�� 5�      -   5         ��Name$ MessageText��5�      $��1��5�      �   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.IsFocusedProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value$
 True��5�      $ Write a message...��5�      #��[ 5�      $��Center=�5�      $��
0 10 10 10q�5�      $��0q�5�       �� 
AcceptsTab$
 True��5�       �� AcceptsReturn$
 True��5�      " �� VerticalScrollBarVisibility$
 Auto=�5�      ��5�      �� *PendingMessageText+$ PropertyChanged=��� 5�      $��2��6   $	 
Horizontal=�5�      $��0 0 8 0q�5�      $	��Top=�5�      .+�5�      �� #��[ 6    	 FontAwesomeEmojiIcon#��[	 5�       
 WordOrangeBrush#��[
 5�      ��5�      �� *	MinHeight+ ��  Grid5�      �� 5�      $
��Send��6   $��8q�5�      $|�False��5�      #��[ 5�        WordGreenBrush#��[ 5�       �� 	IsDefault$
 True��5�      ��5�      �� *SendCommand+5�      5�      5�      5�      5�      