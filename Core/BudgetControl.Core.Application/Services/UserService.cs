using AutoMapper;
using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using BudgetControl.Core.Domain.Entities;
using BudgetControl.Core.Domain.Interfaces;

namespace BudgetControl.Core.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(UserDTO userDTO)
        {
            var mapUser = _mapper.Map<User>(userDTO);
            await _userRepository.Create(mapUser);
        }

        public async Task Delete(UserDTO userDTO)
        {
            var mapUser = _mapper.Map<User>(userDTO);
            await _userRepository.Delete(mapUser);
        }

        public async Task<UserDTO> GetById(int id)
        {
            var result = await _userRepository.GetById(id);

            return _mapper.Map<UserDTO>(result);
        }

        public async Task<UserDTO> GetUserByUsername(string username)
        {
            var result = await _userRepository.GetByName(username);

            return _mapper.Map<UserDTO>(result);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var result = await _userRepository.Get();

            return _mapper.Map<IEnumerable<UserDTO>>(result);
        }

        public async Task Update(UserDTO userDTO)
        {
            var mapUser = _mapper.Map<User>(userDTO);
            await _userRepository.Update(mapUser);
        }
    }
}
