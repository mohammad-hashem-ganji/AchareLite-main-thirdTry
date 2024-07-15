using App.Domain.Core.Member.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public bool IsAccept { get; set; }

        public Expert Expert { get; set; }
        public int ExpertId { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
//< form asp - action = "AddScore" method = "post" >
     
//         < div class= "form-group" >
      
//              < label for= "scoreValue" > Select a score:</ label >
       
//               < select class= "form-control" id = "scoreValue" name = "Value" >
           
//                       < option value = "1" > 1 star </ option >
                
//                            < option value = "2" > 2 stars </ option >
                     
//                                 < option value = "3" > 3 stars </ option >
                          
//                                      < option value = "4" > 4 stars </ option >
                               
//                                           < option value = "5" > 5 stars </ option >
                                    
//                                            </ select >
                                    
//                                        </ div >
                                    
//                                        < input type = "hidden" name = "ExpertId" value = "@Model.ExpertId" />
                                         
//                                             < input type = "submit" value = "Submit Score" class= "btn btn-primary" />
//                                              </ form >
