using System.Collections.Generic;
using ShoppingWebservice.Shared.DTOs;

namespace ShoppingWebservice.Domains.Item.Repository {

    public interface IItemRepository {

        ResponseDto CreateItem(Item item);
        List<Item> GetAllItems();
        ResponseDto GetItem(int itemId);
        ResponseDto UpdateItem(Item item);
        ResponseDto DeleteItem(int itemId);

    }
}
