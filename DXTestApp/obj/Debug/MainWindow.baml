   M S B A M L   `   `   `  ����  	DXTestApp    DXTestApp.MainWindow   5      a ]DevExpress.Xpf.Core.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      e aDevExpress.Xpf.RichEdit.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxre6http://schemas.devexpress.com/winfx/2008/xaml/richedit   5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  6I   c _DevExpress.Xpf.Ribbon.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon   6�     � Title$  
MainWindow��5      $	��800��6   $
��1000��6%    � 	Resources 5      /  )DevExpress.Xpf.RichEdit.RichEditUICommand   commands7  1DevExpress.Xpf.RichEdit.RichEditStringIdConverter  stringIdConverter��%:   &	        &	        5	   
   6!     5
   
   6)   5      .��5      �  � RowDefinitions 5   
   �� 5      $��0.85* �6   6-   �� 5      $��0.15* �6   6-    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   6.   �� 5      $
��0.7* �6   6.   .+�5   
   �� $��0��6   $��0��6"   ��62   �� *Json+-  'DevExpress.Xpf.RichEdit.RichEditControl  5   
   -   5          Name$ richEditControl��5   =   $��0��6   $��1��6,      CommandBarStyle$ Ribbon=�6V   $��2��6o   � 5   
   $��1��6   $��2��6    5      �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   .+�5      �� $+��%Добавить переменную��6   $��0��63   $
��Left=�6@   $	��152��6�   ��6\   �� *ShowAddVariableForm+6�   � 5      $��1��6   .+�5      �� $��Добавить поле��6   $	��110��62   ��6>   �� *
AddField+�� 5       $��38��6   ��6*   �� *	Variables+ �� SelectedValue 6L   �� *SelectedVariable+��5!      �� 5"      .R�5#      �� $��5q�6)   .+�5$   "   �� $��18(�6,   ��6:   ��  �� Path$ NameVar�5%      5&      5(      5)      �� 5*      $��Заполнить��6   $��2��6)   $
��Left=�66   $��92��6R   ��6]   �� *	FillField+5+      5,      5-      