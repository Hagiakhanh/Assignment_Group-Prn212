   M S B A M L   `   `   `  ����J  FAssignmentGroup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AssignmentGroupAssignmentGroup  5   	        AssignmentGroup.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AssignmentGroup     5   	     � Title$  
MainWindow��5   	   $	��450��5	   	   $	��800��5
   	    � WindowStartupLocation$ CenterScreen=�6   .��5      � .+�5   
   �� -   5         ��Name$ 	btnExport��5      $��Export��5      $
��Left=�5      $��
658,59,0,0q�5      $	��Top=�5      $��67��5      5      �� 5   
   -   5        $ 	btnCreate��5      $��Create��6$   $
��Left=�65   $��639,383,0,0q�6P   $	��Top=�6e   $��85��6}   6�   �� 5   
   -   5        $ 	btnUpdate��5      $��Update��6$   $
��Left=�65   $��534,383,0,0q�6P   $	��Top=�6e   $��85��6}   6�   �� 5   
   -   5        $ 
btnImport1��5      $��Import��5      $
��Left=�5      $��
731,59,0,0q�5      $	��Top=�5      $��64��5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridCars��5         AutoGenerateColumns$ False��5      $
��Left=�5      $	��269��5       $��2,87,0,0q�5!      $	��Top=�5"      $	��785��5#         CanUserAddRows$ False��6   �� 5$   
   -   5         ��Name$ ccbCheckBoxFuelName��5$      $��26��60   $	��Top=�6<    �� 
IsEditable$
 True��6U    �� 
IsReadOnly$
 True��6g   $��292,56,414,0q�6�   ��5%      �� 5&      .R�5'      �� -   5        $��0,0,5,0q�5'   3   ��6   �� 6d   5(      5*      �� 5+   
   -   5        $ ccbCheckBoxOwner��5+      $��26��6-   $	��Top=�69   $
 True��6Q   $
 True��6c   $��378,56,366,0q�6�   ��5,      �� 5-      .R�5.      �� -	   5        $��0,0,5,0q�5.   3   ��6   �� 6e   5/      51      �� 52   
   -
   5        $ ccbCheckBoxSellerType��52      $��26��62   $	��Top=�6>   $
 True��6V   $
 True��6h   	 J� RenderTransformOrigin$	 0.518,0.515&�6�   $��426,56,270,0q�6�   ��53      �� 54      .R�55      �� -   5        $��0,0,5,0q�55   3   ��6   �� 6f   56      58      �� 59   
   -   5        $ ccbCheckBoxTransmission��59      $��26��64   $	��Top=�6@   $
 True��6Y   $
 True��6k   $��524,56,157,0q�6�   ��5:      �� 5;      .R�5<      �� -   5        $��0,0,5,0q�5<   4   ��6   �� 6m   5=      5?      �� 5@   
   -   5        $��Apply��5@      $
��Left=�6!   $��	605,8,0,0q�6<   $	��Top=�6O   $��85��6g   $��19��6r   $	 0.395,0.739&�6�   �� 5A   
   -   5        $ ccbCheckBoYear��5A      $��26��6+   $	��Top=�67   $
 True��6O   $
 True��6a   $��45,57,711,0q�6�   ��5B      �� 5C      .R�5D      �� -   5        $��0,0,5,0q�5D   3   ��6   �� 6d   5E      5G      �� 5H   
   -   5        $ ccbTypeRange��5H      $
��Left=�6)   $��	167,3,0,0q�6D   $	��Top=�6W   $	��106��6o   $��25��6{   �� 5I   
   -   5        
 ��Name$
 txt_minRange��5I      $
��Left=�6(   $��	327,8,0,0q�6C    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   $��98��6�   �� 5J   
   -   5        $
 txt_maxRange��5J      $
��Left=�6(   $��	488,8,0,0q�6C   $
 Wrap=�6V   $	��Top=�6j   $��98��6�   �� 5K   
   $
��Min:��6   $
��Left=�6   $��	290,3,0,0q�6:   $	��Top=�6M   $	 0.305,0.406&�6e   �� 5L   
   $
��Max:��6   $
��Left=�6   $��	447,1,0,0q�6:   $	��Top=�6M   $	 0.305,0.406&�6e   �� 5M   
   -   5        $ ccbSort��5M      $
��Left=�6$   $��11,5,0,0q�6?   $	��Top=�6Q   $	��118��6i   $��25��6u   �� 5N   
   -   5        $��Clear��5N      $
��Left=�6!   $��	711,9,0,0q�6<   $	��Top=�6O   $��85��6g   $��19��6r   6~   �� 5O   
   -   5        $ 	btnDelete��5O      $��Delete��6$   $
��Left=�65   $��422,383,0,0q�6P   $	��Top=�6e   $��85��6}   6�   5Q      5S      