using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Terraform.ResourceDomain;
using Terraform.WinApplication.ViewModels;
using Terraform.WorkDomain;

namespace Terraform.WinApplication.UserControls
{
    /// <summary>
    /// Interaction logic for ResourceQuantityRequirementView.xaml
    /// </summary>
    public partial class ResourceQuantityRequirementView : UserControl
    {
        public static readonly DependencyProperty RequirementProperty =
            DependencyProperty.Register("Requirement",
                typeof(ResourceQuantityRequirement), typeof(ResourceQuantityRequirementView)/*, new PropertyMetadata(null)*/);

        public ResourceQuantityRequirement Requirement
        {
            get { return (ResourceQuantityRequirement)GetValue(RequirementProperty); }
            set { SetValue(RequirementProperty, value); }
        }
                
        public ResourceQuantityRequirementView()
        {
            InitializeComponent();
        }
    }
}
