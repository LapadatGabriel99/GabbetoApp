   M S B A M L   `   `   `  ���� G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core     Fasseto.Word.ChatPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Fasseto.Word     Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core     -      Fasseto.Word.BasePage`1   Name$
  Page��$	��400��$	��400��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� 
������ $��2�� K� ZIndex$ 1��y��� *AnyPopupMenuVisible+ �� 	Converter /   )Fasseto.Word.BooleanToVisibilityConverter   �� ConverterParameter$
 True�� J� InputBindings d�  d� MouseAction$ 	LeftClicke� �� Command �� *PopupClickAwayCommand+� $��50�� � ColumnDefinitions �� $��* ��� $
��Auto �.+���    ForegroundLightBrush#��[    FontSizeXLarge#��[ $��Center=�$��Center=�$��2������ *DisplayTitle+�� $��1��	 �� Orientation$	 
Horizontal=�.+���   ChatPageIconGrowButton#��[   FontAwesomeSearchIcon#��[ ���� *OpenSearchCommand+�� #��[  # FontAwesomeEllipsisVerticalIcon#��[ � $��2���   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.AnimateSlideInFromRightMarginProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]
   Value
 �� *SearchIsOpen+ �� $
��Auto ��� $��* �.+��� -   #��[   FontAwesomeCloseIcon#��[ #��[  ���� *CloseSearchCommand+�� $��1��
 � Tag$ Search text...��$��0 5 5 5q�  FontSizeRegular#��[ ���� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=��   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.FocusProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value �� *SearchIsOpen+.�� �� 
 �� Key$ Return�� �� *SearchCommand+�� $	 Esc�� �� *ClearSearchCommand+.��)   #Fasseto.Word.ChatMessageListControl  -     Name$ ChatMessageList��$��1�� � DataContext �� �� $��1��$��Bottom=�$
��Left=�$ 2���   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.AnimateSlideInFromBottomProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value �� *AttachementMenuVisible+._�    Fasseto.Word.BubbleContent   �� *AttachementMenu+� $��2��$ 3��$��50��$	��114��#��[   �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��[   FontAwesomePaperClipIcon#��[   ForegroundDarkBrush#��[ $	��Top=����� *	MinHeight+ �� RelativeSource ��  �� AncestorType Grid���� *AttachmentButtonCommand+�� -    ��Name$ MessageText��$��1���   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.IsFocusedProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value$
 True��$ Write a message...��#��[ $��Center=�$��
0 10 10 10q�$��0q� �� 
AcceptsTab$
 True�� �� AcceptsReturn$
 True��" �� VerticalScrollBarVisibility$
 Auto=����� *PendingMessageText+$ PropertyChanged=��� $��2��$	 
Horizontal=�$��0 0 8 0q�$	��Top=�.+��� #��[  	 FontAwesomeEmojiIcon#��[	  
 WordOrangeBrush#��[
 ���� *	MinHeight+ ��  Grid�� $
��Send��$��8q�$|�False��#��[   WordGreenBrush#��[  �� 	IsDefault$
 True������ *SendCommand+