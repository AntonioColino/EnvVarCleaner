   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   G CEnvCleanerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EnvCleanerUIEnvCleanerUI 5   	      EnvCleanerUI.EditWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7core&clr-namespace:System;assembly=mscorlib     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ,localclr-namespace:EnvCleanerUI     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
EditWindow��5   	   $	��679��5	   	   $	��125��5
   	   {�.  � OverridesDefaultStyle .   � 
ResizeMode$ NoResize=�5   	    � ShowActivated .  � ShowInTaskbar .   � SizeToContent$ WidthAndHeight=�5   	    � Topmost .  � WindowStartupLocation$ CenterOwner=�5   	    � WindowState$ Normal=�5   	   	 � WindowStyle$	 
ToolWindow=�5   	   
 � DataContext
 5   	   �� *	EditModel+ �� RelativeSource �� *FindAncestor+ �� AncestorType  EnvCleanerUI.EditWindow"   � 	Resources 5         EnvCleanerUI.FlipConverter   FlipConverter��%   &	          5   
   6   5      .��5      �� $��0,0,4,9q�6    5   
    
 MyEnum S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� Type&    System.EnvironmentVariableTarget��%m   &	       S� 5      $ 	GetValues��5   !   "  5    !    5!      M� 5"      "  6   5$      5%      .+�5&   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $	��669��6K   $��45��6W   .+�5'      �� -   5         ��Name$ NameTextBox��5'      $	��250��5(      $��24��5)      $��10,0,0,0q�5*       �� TextWrapping$
 Wrap=�53       �� 
IsReadOnly 5+      �� *EditModel.CanEditName+ �� 	Converter# [   �� BindsDirectlyToSource .  �� *FindAncestor+"  ��50      �� *EditModel.Name+ �� *FindAncestor+"  53      �� 54      -   5        $ ValueTextBox��54      $	��250��55      $��24��56      $��0,0,0,0q�57      $ WrapWithOverflow=�5@       58      �� *EditModel.CanEditValue+# [   .  �� *FindAncestor+"  ��5=      �� *EditModel.Value+ �� *FindAncestor+"  5@      �� 5A      -   5         ��Name$ TargetComboBox��5A      $	��150��5B      $��24��5C      $��	0,10,0,10q�5D      $��Stretch=�5E      $��Stretch=�5F      $
��Left=�5G      $��Center=�5H       �� SelectedIndex$ 0��5O       �� 
IsReadOnly 5I      �� *EditModel.CanEditTarget+# [   .  �� *FindAncestor+"  ��5N      ��  �� Source# [  �� Text 5P      �� *EditModel.Target+ .  �� *FindAncestor+"  5T      �� 5U   
   $ 
Horizontal=�6   .+�5V      �� -   5        $	��120��5V      $��30��5W      $��50,10,10,10q�5X      $��Delete��5Z      $y�Hidden=�5[      �� 5\      -   5        $	��120��5\      $��30��5]      $��10,10,10,10q�5^      $��Cancel��5`      �� 5a      -   5        $	��120��5a      $��30��5b      $��10,10,50,10q�5c      $
��Save��5e      5f      5g      5h      