using ChatGptAppBackend.APIs.Common;
using ChatGptAppBackend.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatGptAppBackend.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ConversationFindManyArgs : FindManyInput<Conversation, ConversationWhereInput> { }
