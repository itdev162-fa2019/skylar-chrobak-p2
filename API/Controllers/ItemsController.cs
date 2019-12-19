using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController: ControllerBase{
        private readonly DataContext context;
        public ItemsController(DataContext context){
            this.context = context;
        }
        //GET List of items
        [HttpGet]
        public ActionResult<List<Item>> GetAction() {
            return this.context.Items.ToList();
        }
        //GET a single item based on ID
        [HttpGet("{id")]
        public ActionResult<ItemsController>GetById(Guid id){
            return this.context.Items.Find(id);
        }
        //POST new item on list
        [HttpPost]
        public ActionResult<ItemsController> Create([FromBody]Item request){
            var item = new ItemsController{
                Id = request.Id,
                Title=request.Title,
                Body=request.Body,
                Date=request.Date
            };
            context.Items.Add(item);
            var success = context.SaveChanges() > 0;
            if (success){
                return item;
            }
            throw new Exception("Error creating new list item");
        }
        public ActionResult<Item> Update([FromBody]ItemsController request){
            var item = context.Items.Find(request.Id);
            if (item== null){
                throw new Exception("Could not find item");
            }

            //UPDATE list items if there are none
            item.Title = request.Title !=null ? request.Title: item.Title;
            item.Body = request.Body != null ? request.Body: item.Body;
            item.Date = request.Date !=null ? request.Date: item.Date;
            
            var success = context.SaveChanges() >0;
            if (success){
                return item;
            }
            throw new Exception("Error updating list item");   
        }
        ///DELETE item from shopping list once bought
        [HttpDelete("{id")]
        public ActionResult<bool>Delete(Guid id){
            var item=context.Items.Find(id);
            if (item==null){
                throw new Exception("Could not find item");
            }
            context.Remove(item);
            var success=context.SaveChanges()>0;
            if (success){
                return true;
            }
            throw new Exception("Error deleting item");
        }
    }
}